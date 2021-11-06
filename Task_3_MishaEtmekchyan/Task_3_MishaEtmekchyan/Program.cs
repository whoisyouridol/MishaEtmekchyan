using System;
using System.IO;

namespace Task_3_MishaEtmekchyan
{
    class Program
    {
        static void GetText(string dir)
        {
            if (dir == "exit")
            {
                return;
            }
            else if (Directory.Exists(dir))
            {
                if (Directory.GetDirectories(dir).Length > 0)
                {
                    for (int i = 0; i < Directory.GetDirectories(dir).Length; i++)
                    {
                        var newDir = Directory.GetDirectories(dir)[i];
                        GetText(newDir);
                    }
                }
                for (int i = 0; i < Directory.GetFiles(dir).Length; i++)
                {
                    Console.WriteLine(Directory.GetFiles(dir)[i]);
                }
                return;
            }
            else
            {
                Console.WriteLine("This directory does not exist.");
                Console.WriteLine("Input directory : ");
                string dir_new = Console.ReadLine();
                GetText(dir_new);
            }
        }
        static void Main(string[] args)
        {
            GetText(@"C:\TestFolder");
        }
    }
}
