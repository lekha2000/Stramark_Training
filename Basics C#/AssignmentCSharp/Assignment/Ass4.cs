using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Assignment

{
    class Ass4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of an array");
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the data type");
            string typeName = Console.ReadLine();
            Type type = Type.GetType(typeName, true, true);
            Array myArray = Array.CreateInstance(type, size);

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter the value of the type {type.Name}");
                string enteredValue = Console.ReadLine();
                object convertedValue = Convert.ChangeType(enteredValue, type);
                myArray.SetValue(convertedValue, i);
            }
            Console.WriteLine("All the Values are set");
            foreach (object i in myArray)
            {
                Console.WriteLine(i);
            }

        }
            
    }
}
/*Console.WriteLine("Enter the size of an array");
        int size = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the data type");
        string type = Console.ReadLine();
        switch (type)
        {
            case "int":
                {
                    int[] array = new int[size];
                    Console.WriteLine("Enter the numbers");
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("Entered array is");
                    for (int j = 0; j < array.Length; j++)
                        Console.WriteLine(array[j]);
                    break;
                }
            case "double":
                {
                    double[] array = new double[size];
                    Console.WriteLine("Enter the numbers");
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = Convert.ToDouble(Console.ReadLine());
                    }
                    Console.WriteLine("Entered array is");
                    for (int j = 0; j < array.Length; j++)
                        Console.WriteLine(array[j]);
                    break;
                }
            case "string":
                {
                    string[] array = new string[size];
                    Console.WriteLine("Enter the numbers");
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = Console.ReadLine();
                    }
                    Console.WriteLine("Entered array is");
                    for (int j = 0; j < array.Length; j++)
                        Console.WriteLine(array[j]);
                    break;
                }
            case "decimal":
                {
                    decimal[] array = new decimal[size];
                    Console.WriteLine("Enter the numbers");
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = Convert.ToDecimal(Console.ReadLine());
                    }
                    Console.WriteLine("Entered array is");
                    for (int j = 0; j < array.Length; j++)
                        Console.WriteLine(array[j]);
                    break;
                }
            default:
                Console.WriteLine("Invalid");
                break;

        }


    */
