using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace BinarySystem
{
    class Program
    {



     
        static void Main(string[] args)
        {
            string intword;
            intword = Console.ReadLine();

            BinaryWriter bw;
            BinaryReader br;

            //string[] head = new string[] { "0x12", "0x34", "0x56", "0x78", "0x90" };
            byte[] head = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90 };
            byte[] foot = new byte[] { 0x01 };
            byte[] bodyorgan = new byte[0];
            byte[] bodydirection = new byte[0];
            byte[] bodypart = new byte[2022];

            if (intword.Contains("手臂"))
            {
                Console.WriteLine("01");
                bodyorgan = new byte[] { 0x01 };
            }
            if (intword.Contains("足"))
            {
                bodyorgan = new byte[] { 0x02};
            }
            if (intword.Contains("左"))
            {
                bodydirection = new byte[] { 0x01 };
            }
            if (intword.Contains("右"))
            {
                bodydirection = new byte[] { 0x02 };
            }

            for (var i = 0; i < 2022 ; i++){
                bodypart[i]=0x00;
            }

            //创建一个文件流
            bw = new BinaryWriter(new FileStream("module1", FileMode.Create));
            //将byte数组写入文件中
            bw.Write(head, 0, head.Length);
            bw.Write(bodyorgan, 0, bodyorgan.Length);
            bw.Write(bodydirection, 0, bodydirection.Length);
            bw.Write(bodypart, 0, bodypart.Length);
            bw.Write(foot, 0, foot.Length);
            //所有流类型都要关闭流，否则会出现内存泄露问题
            bw.Close();

            Console.WriteLine("保存文件成功");


            //string[] data3 = new string[head.Length + bodyorgan.Length + bodydirection.Length+ bodypart.Length+foot.Length];
            //head.CopyTo(data3, 0);
            //bodyorgan.CopyTo(data3, head.Length);
            //bodydirection.CopyTo(data3, head.Length + bodyorgan.Length);
            //bodypart.CopyTo(data3, head.Length + bodyorgan.Length + bodydirection.Length);
            //foot.CopyTo(data3, head.Length + bodyorgan.Length + bodydirection.Length + bodypart.Length);
            //Console.WriteLine(string.Join("\n", data3));
            //Console.WriteLine("Hello World!");

            //try
            //{
            //    bw = new BinaryWriter(new FileStream("module1", FileMode.Create));
            //}
            //catch (IOException e)
            //{
            //    Console.WriteLine(e.Message + "\n Cannot create file.");
            //    return;
            //}

            //try//尝试写入二进制文件
            //{
            //    //bw.Write(i);
            //    //bw.Write(d);
            //    //bw.Write(b);
            //    byte[] array = Encoding.UTF8.GetBytes(string.Join("\n", data3));
            //    bw.Write(array);//写入四行，每次写入一行
            //}
            //catch (IOException e)
            //{
            //    Console.WriteLine(e.Message + "\nCannot write to file.");
            //    return;
            //}

            //bw.Close();//执行完写入程序后关闭该二进制文件

        }
    }
}
