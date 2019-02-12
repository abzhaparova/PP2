using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        public static void numbers(int[] arr, int[] arr1, int q, int x, int n, string[] str)//functon 
        {
            for (int i = 0; i < n; i++)//runs till n 
            {
                arr[i] = Convert.ToInt32(str[i]);//Converting from string to integer
            }
            for (int i = 0; i < n; i++)//runs till n 
            {
                for (int j = q; j < x; j++)//runs till x 
                {
                    arr1[j] = arr[i];//2nd array's 2nd element equals to 1st array's 1st element
                }
                q += 2;//Adding 2 to increase array's location
            }
            for (int i = 0; i < x; i++)//runs till x 
            {
                Console.Write(arr1[i] + " ");//output numbers of arr1 + space
            }
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());//size of array
            int[] arr = new int[n];//one dim array with size n
            int x = n * 2; //multiply by 2 to 2nd array            
            int q = 0; //new int 
            int[] arr1 = new int[x]; //one dim array with size x
            string s = Console.ReadLine();//transfer the string 
            string[] str = s.Split(); //Every element splitted by space
            numbers(arr, arr1, q, x, n, str); //calling the function called numbers 

            Console.ReadKey();
        }
    }
}

