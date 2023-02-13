using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssignments
{

    class Array
    {
        static void Trans(int[,] arr)
        {

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    sum += arr[i, j];
                    Console.Write(arr[i, j] + " ");
                }
                Console.Write(sum);
                Console.WriteLine();
            }
        }
