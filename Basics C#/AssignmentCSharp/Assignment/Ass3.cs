using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Ass3
    {
        public static void Main()
        {
            int num1, num2;
            char operation;

            Console.Write("Input first number: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input operation: ");
            operation = Convert.ToChar(Console.ReadLine());
            Console.Write("Input second number: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            if (operation == '+')
                Console.WriteLine("{0} + {1} = {2}", num1, num2, num1 + num2);
            else if (operation == '-')
                Console.WriteLine("{0} - {1} = {2}", num1, num2, num1 - num2);
            else if ((operation == 'x') || (operation == '*'))
                Console.WriteLine("{0} * {1} = {2}", num1, num2, num1 * num2);
            else if (operation == '/')
                Console.WriteLine("{0} / {1} = {2}", num1, num2, num1 / num2);
            else
                Console.WriteLine("Wrong Character");
            Console.WriteLine();
        }
    }
}
   

