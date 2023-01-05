using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Ass5
    {
        static void Main(string[] args)
        {
            //used to create a copy of an object of a class which implements Cloneable interface.
            Console.WriteLine("Clone Example");
            string name1 = "Jack";
            string name2 = (String)name1.Clone();
            //{0} used to print with message 
            Console.WriteLine("Name: {0} ", name1);
            Console.WriteLine("Clone Name: {0} ", name2);

            Console.WriteLine("\nCopyTo Example");
            string s1 = "Hello C#, How Are You?";
            char[] ch = new char[15];
            //CopyTo(index , char type, start, end)
            s1.CopyTo(6, ch, 0, 12);
            Console.WriteLine(ch);
        }
    }
}
