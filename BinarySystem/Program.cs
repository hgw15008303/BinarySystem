using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace BinarySystem
{
    class Program
    {


        public static void binary(string filepath,string content, byte num)
        {
            FileStream fs;
            byte[] head = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90 };
            //  byte[] foot = new byte[] { 0x01+j };
            byte[] foot = new byte[] { (byte)(0x01 + num) };
            byte[] bodyorgan = new byte[0];
            byte[] bodydirection = new byte[0];
            byte[] bodypart = new byte[2022];

            if (content.Contains("手臂"))
            {
                Console.WriteLine("01");
                bodyorgan = new byte[] { 0x01 };
            }
            if (content.Contains("足"))
            {
                bodyorgan = new byte[] { 0x02 };
            }
            if (content.Contains("左"))
            {
                bodydirection = new byte[] { 0x01 };
            }
            if (content.Contains("右"))
            {
                bodydirection = new byte[] { 0x02 };
            }

            for (var i = 0; i < 2022; i++)
            {
                bodypart[i] = 0x00;
            }
            //创建一个文件流
            fs = new FileStream(filepath, FileMode.Append);
            //将byte数组写入文件中
            fs.Write(head, 0, head.Length);
            fs.Write(bodyorgan, 0, bodyorgan.Length);
            fs.Write(bodydirection, 0, bodydirection.Length);
            fs.Write(bodypart, 0, bodypart.Length);
            fs.Write(foot, 0, foot.Length);
            //所有流类型都要关闭流，否则会出现内存泄露问题
            fs.Close();
        }
     
        static void Main(string[] args)
        {
            string intword;
            intword = Console.ReadLine();
            System.IO.File.WriteAllText(@"function1.txt", string.Empty);
            System.IO.File.WriteAllText(@"function2.txt", string.Empty);
            if (intword.Contains(","))
            {
                for (int i = 0; i < Regex.Matches(intword, ",").Count +1; i++)
                  
                binary("function2.txt", intword, (byte)(0x00+i));
            }
            else
            {
              
                binary("function1.txt", intword, 0);
            }

            Console.WriteLine("保存文件成功");


        }
    }
}
