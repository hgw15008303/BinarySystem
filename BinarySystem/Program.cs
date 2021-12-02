using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace BinarySystem
{
    class Program
    {


        //生成特定的二进制编码
        public static void binarygenerate(string filepath,string content, byte num)
        {
         //   System.IO.File.WriteAllText(@filepath, string.Empty);

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

        //拆分二进制编码
        public static void binarysplit(string filepath)
        {
            FileStream fs = new FileStream(filepath, FileMode.Open);
            FileStream fssplit;
            //获取文件大小（长度）
            long size = fs.Length;
            byte[] binaryarray = new byte[size];
            byte[] binarysplitone = new byte[0];
            var n = 0;
            //将文件读到byte数组中
            fs.Read(binaryarray, 0, binaryarray.Length);
            for (var i = 0; i < binaryarray.Length; i++)
            {
              if(binaryarray[i] == 0x12)
                {
                    n++;
                }
             
            }
            //定长
            var fixedlength = (int)(size / n);
            //var fixedlength = 3;
            for(var j = 0; j < n; j++)
            {
                //创建一个文件流
                fssplit = new FileStream("split" + (j+1) + ".txt", FileMode.Create);
                fssplit.Write(binaryarray, 0+j*fixedlength, fixedlength);
                fssplit.Close();
            }
            ////创建一个文件流
            //fssplit = new FileStream("split" + n + ".txt", FileMode.Create);
            //fssplit.Write(binaryarray, 0, fixedlength);
            //fssplit.Close();
            fs.Close();
            Console.WriteLine("拆分完成");


            //  Console.WriteLine(string.Join("\n", array));
        }
        

            static void Main(string[] args)
        {

            //////生成特定的二进制编码
            ////string intword;
            ////intword = Console.ReadLine();
            ////System.IO.File.WriteAllText(@"function1.txt", string.Empty);
            ////System.IO.File.WriteAllText(@"function2.txt", string.Empty);

            ////if (intword.Contains(","))
            ////{
            ////    string[] intwordsplit = intword.Split(',');
            ////    //Console.WriteLine(intwordsplit[0]);

            ////    for (int i = 0; i < Regex.Matches(intword, ",").Count + 1; i++)

            ////        binarygenerate("function2.txt", intwordsplit[i], (byte)(0x00 + i));
            ////}
            ////else
            ////{
            ////    binarygenerate("function1.txt", intword, 0);
            ////}

            ////Console.WriteLine("保存文件成功");


            //拆分二进制编码
            binarysplit("function2.txt");



        }
    }
}
