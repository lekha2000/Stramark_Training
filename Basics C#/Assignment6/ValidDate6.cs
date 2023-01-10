
using System;
namespace AssignmentFunction 

    class CheckDate
    {

        const int MAXYEAR = 9999;
        const int MINYEAR = 1800;

        // Returns true if given year is valid or not.
        static bool isValidDate(int day, int month, int year)
        {
            // If year, month and day are not in given range
            if (year > MAXYEAR || year < MINYEAR)
                return false;

            if (month < 1 || month > 12)
                return false;

            if (day < 1 || day > 31)
                return false;

            // February month to check for leap year
            if (month == 2)
            {
                if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0))
                    return (day <= 29);
                else
                    return (day <= 28);
            }

            // Months of April, June,
            // Sept and Nov must have
            // number of days less than
            // or equal to 30.
            if (month == 4 || month == 6 || month == 9 || month == 11)
                return (day <= 30);

            return true;
        }

        // Driver code
        public static void Main()
        {
            Console.WriteLine("Enter the Day in dd");
            int Day = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Month in mm");
            int Month = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Year in yyyy");
            int Year = Int16.Parse(Console.ReadLine());

            if (isValidDate(Day, Month, Year))
                Console.Write($"The Entered {Day}/{Month}/{Year} is Valid ");
            else
                Console.WriteLine($"The Entered {Day}/{Month}/{Year} is Not Valid ");
        }
    }
}


