using System;

namespace AssignmentFunction
{
    class SimpleIntrest
    {
        public static float SimpleIntrest(float P, float R, float T)
        {
            float SI = (P * R * T) / 100;
            Console.WriteLine("Simple Intrest :  " + SI);
            return SI;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter the Principal Amount : ");
            float PrincipalAmount = float.Parse(Console.ReadLine());
            Console.Write("Enter the Intrest Rate : ");
            float IntrestRate = float.Parse(Console.ReadLine());
            Console.Write("Enter the Time : ");
            float Time = float.Parse(Console.ReadLine());
            SimpleIntrest(PrincipalAmount, IntrestRate, Time);

        }
    }
    
}
