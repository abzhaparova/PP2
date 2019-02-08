using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primes
{
    class Program //name of the class
    {
        public static bool IsPrime(int n) //Isrime function with a parameter for one number, which checks whether the given number is prime or not by counting how many times the number is divided for i without any reminder 
        {
            int cnt = 0;//the counting starts at zero 
            for (int i = 1; i <= n; i++)//run till n 
            {
                if (n % i == 0)// if the number is divisible by i, which means that if the given number divides without reminder then increment cnt
                {
                    cnt++;//incrementing cnt
                }
                if (cnt == 2) //this condition checks, if the cnt is equal to 2 then it returns true which means that the number is prime, else returns false, which means that the number is not prime
                    return true;
                else
                    return false;
            }

            static void Main(string[] args)
            {
                String a = Console.ReadLine();//created string a
                int aa = int.Parse(a);//converting string to int

                var primes = new List<int>();// creating list for adding primes

                String b = Console.ReadLine();//created string b 
                String[] nums = b.Split(' ');// splits after " "  in order to read every giving number 

                for (int i = 0; i < aa; i++)//run till aa
                {

                    int numm = int.Parse(nums[i]);// convert our string into integer
                    if (IsPrime(numm))//if the given condition holds or the function is true
                    {
                        primes.Add(numm);// then this condition adds these numbers to the prime list
                    }
                }

                Console.WriteLine(primes.Count);//count the given primes and show output 
                for (int i = 0; i < primes.Count; i++)//runs till prime counts
                {
                    Console.Write(primes[i] + " ");//then show the each prime number as output
                }
                Console.ReadKey();//pausing after execution of the program
            }
        }
    }
}
