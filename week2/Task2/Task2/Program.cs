using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program //name of the class
    {
        public static bool IsPrime(int n) //Isrime function with a parameter of one number, which checks whether the given number is prime or not by counting how many times the number is divided for i without any reminder 
        {
            int cnt = 0;//the counting starts at zero 
            for (int i = 1; i <= n; i++)//run till n 
            {
                if (n % i == 0)// if the number is divisible by i, which means that if the given number divides without reminder then increment cnt
                {
                    cnt++;//incrementing cnt
                }
            }

            if (cnt == 2) //this condition checks, if the cnt is equal to 2 then it returns true which means that the number is prime, else returns false, which means that the number is not prime
                return true;
            else
                return false;
        }

        static void Main(string[] args) // main function
        {
            StreamReader sr = new StreamReader(@"C:\Users\Aida\Desktop\pp2\PP2\week2\Task2\input.txt"); // streamreader reads text from txt files
            string[] s = (sr.ReadLine()).Split(' '); // creating the string and read all elements in the txt to the end and split them into substrings
            StreamWriter sw = new StreamWriter(@"C:\Users\Aida\Desktop\pp2\PP2\week2\Task2\output.txt"); // streamwriter writes elements into a text files
            for (int i = 0; i < s.Length; i++)//runs till the length of s
            {
                if (IsPrime(Int32.Parse(s[i])))//converting substrings to int and if the function IsPrime is true, then this condition does next step
                {
                    sw.Write(s[i] + " "); // if the numbers are prime, put them in output txt file 
                }
            }
            
            sw.Close(); // closes StreamWriter 
            sr.Close();//closes StreamReader
        }
    }
}

