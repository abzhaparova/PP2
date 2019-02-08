using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string star = Console.ReadLine();//creating string 
            int star1 = int.Parse(star);//converting string to int 

            for (int i = 0; i <= star1; i++)//runs till star1
            {
                for (int j = 0; j <= i; j++)//runs till i 
                {
                    Console.Write("[*]");//writing [*]
                }
                Console.Write("\n");//creating a new line 
            }
            Console.ReadKey();//pausing the execution of the program 
        }
    }
}

