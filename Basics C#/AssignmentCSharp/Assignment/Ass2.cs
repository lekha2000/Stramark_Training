using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Ass2
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] {111,25,300,77,34,59,42,99 };
            int[] arr2 = new int[8];
            int[] arr3 = new int[8];
            int i, j = 0, k = 0;

            Console.WriteLine("Array Elements ");
            for ( i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Checks Array For Odd Even Numbers \n");
            for (i = 0; i < 8; i++)
            {

                if (numbers[i] % 2 == 0)
                {
                    arr2[j] = numbers[i];
                    j++;
                }
                else
                {
                    arr3[k] = numbers[i];
                    k++;
                }
            }
                Console.WriteLine("Even numbers...");
                for (i = 0; i < j; i++)
                {
                    Console.WriteLine(arr2[i]);
                }
                Console.WriteLine();
                Console.WriteLine("Odd numbers...");
                for (i = 0; i < k; i++)
                {
                    Console.WriteLine(arr3[i]);
                }
                Console.WriteLine();
        }
        }
    }
