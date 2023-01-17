using System;

namespace AssignmentFunction
{
    class Reverse
    {
        public static string reverseStr(string name)
        {
            string[] words = name.Split(" ");

            for (int i = words.Length - 1; i > -1; i--)
            {
                Console.Write($"{words[i]}" + " ");
            }
            return null;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the String");
            string sentence = Console.ReadLine();
            reverseStr(sentence);
        }
    }
    
}
