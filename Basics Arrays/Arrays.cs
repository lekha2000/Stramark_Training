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
        static void Date()
        {

            Console.WriteLine(" Enter the Date as dd/mm/yyy");
            DateTime dd = DateTime.ParseExact(Console.ReadLine(), "dd/mm/yyyy", null);
            for (int i = -1; i >= 15; i--)
            {
                Console.WriteLine(dd.AddDays(i));
            }
        }
        static void Countstr()
        {
            Console.WriteLine("Enter The String: ");
            string str = Console.ReadLine();
            int alphct = 0;
            int digtct = 0;
            //int eqlcnt = 0;
            int specialcnt = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'a' && str[i] <= 'z' || str[i] >= 'A' && str[i] <= 'Z')
                {
                    alphct++;
                }
                else if (str[i] >= 0 && str[i] <= 9)
                {
                    digtct++;
                }
                else
                {
                    specialcnt++;
                }

                // Console.WriteLine(str[i]);
            }
            Console.WriteLine("Alphabet count : " + alphct);
            Console.WriteLine(" digit count : " + digtct);
            Console.WriteLine("Special char : " + specialcnt);
        }
        static void LtoU()
        {
            Console.WriteLine("Enter any String");
            var str1 = Console.ReadLine();

            char[] arr1 = str1.ToCharArray(0, str1.Length); ;

            for (int i = 0; i < str1.Length; i++)
            {
                
                if (Char.IsLower(arr1[i]))
                    Console.Write(Char.ToUpper(arr1[i]));
                else
                    Console.Write(Char.ToLower(arr1[i]));
            }
            Console.Write("\n");

        }
                static void Main(string[] args)
        {

            int[,] arr = { { 1, 2, 3, }, { 4, 5, 6 }, { 7, 8, 9 } };
            //Trans(arr);
            Date();
            //Countstr();
            //LtoU();
        }
    }

}
