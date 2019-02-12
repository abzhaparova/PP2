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
            static void IsPalindrome(string s)
            {
                bool p = true;

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[s.Length - 1 - i] != s[i])
                    {
                        p = false;
                        break;
                    }
                }

                if (p)
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

                sr.Close();
                fs.Close();
                Console.ReadKey();
            }
        }
    }