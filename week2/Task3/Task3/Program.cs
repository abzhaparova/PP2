using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Program
    {
        public static void Spaces(int level)//this function prints spaces "level" times
        {
            for (int i = 0; i < level; i++)//cycle for printing spaces 
            {
                Console.Write(" ");//prints spaces
            }

        }
        public static void Directory(DirectoryInfo direct, int level)//Directory function
        {
            FileInfo[] files = direct.GetFiles();//getfile returns the list of its files which are saved in Array FileInfo
            DirectoryInfo[] directories = direct.GetDirectories();//getDirectory returns the list of its folders which are saved in Array DirectoryInfo

            foreach (FileInfo file in files)//cycle for files
            {
                Spaces(level);//Calling the function "Spaces" with level to separate by space our files
                Console.WriteLine(file.Name);// Shows the Name of each file from the given directory
            }

            foreach (DirectoryInfo dir in directories)//cycle for directories
            {
                Spaces(level);//Calling the function "Spaces" with level to separate by space our folders
                Console.WriteLine(dir.Name);//show the name of the folders 
                Directory(dir, level + 1);//recursivly recalling the origin funciton with another directory and level 
            }
        }

        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Aida\Desktop\EWB5_12");//// Writing the path to the directory With which we work
            Directory(dir, 0);//Call the function Directory with dir and 0(the number of spaces at the begining)

            Console.ReadKey();
        }
    }
}