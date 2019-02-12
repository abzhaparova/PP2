using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1new
    {
        class Program
        {
            static void IsPalindrome(string s)//this function is created in order to check whether the writtin string is palindrome or not 
            {
                bool p = true;

                for (int i = 0; i < s.Length; i++)//running from 0 till the length of string s 
                {
                    if (s[s.Length - 1 - i] != s[i])//comapres elements between each other
                    {
                        p = false;
                        break;
                    }
                }

                if (p)//if the above funciton is true then output will be yes, else will be no
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }

            static void Main(string[] args)
            {
                FileStream fs = new FileStream(@"C:\Users\Aida\Desktop\pp2\PP2\week2\Task1new\task1.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string line = sr.ReadLine();

                IsPalindrome(line);

                sr.Close();//closes StreamReader
                fs.Close();//closes FileStream
                Console.ReadKey();// holds terminal open , until we press any key to do so
        }
        }
    }