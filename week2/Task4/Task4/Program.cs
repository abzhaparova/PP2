using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        public static void CreateCopyDeleteFile()
        {

            StreamWriter file = new StreamWriter(@"C:\Users\Aida\Desktop\pp2\PP2\week2\Task4\path\file.txt");   
            file.WriteLine("Smile:) have a great day!");
            file.Close();
            File.Copy("C:/Users/Aida/Desktop/pp2/PP2/week2/Task4/path/file.txt", "C:/Users/Aida/Desktop/pp2/PP2/week2/Task4/path1/file.txt");
            File.Delete("C:/Users/Aida/Desktop/pp2/PP2/week2/Task4/path/file.txt");
        }

        static void Main(string[] args)
        {
            CreateCopyDeleteFile();
            Console.ReadKey();
        }
    }
}

