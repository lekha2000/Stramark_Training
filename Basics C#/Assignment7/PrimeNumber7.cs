using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentFunction
{
    class PrimeNumber
    {
        public static bool Chkprime(int num)
        {
            for (int i = 2; i < num; i++)
                if (num % i == 0)
                    return false;
            return true;
        }
        public static void Main()
        {
            Console.Write("Enter the Number : ");
            int n = Convert.ToInt32(Console.ReadLine());

            if (Chkprime(n))
                Console.WriteLine(n + " is a prime number");
            else
                Console.WriteLine(n + " is not a prime number");
        }
    }
}
