using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Employee
    {
        int id;
        string name, address;
        double salary;

        public int EmpId
        {
            get { return id; }
            set { id = value; }
        }
        public string EmpName
        {
            get { return name; }
            set { name = value; }
        }
        public string EmpAddress
        {
            get { return address; }
            set { address = value; }
        }
        public double EmpSalary
        {
            get { return salary; }
            set { salary = value; }
        }
    }
    class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public double Bsalary { get; private set; } = 30000;

        public void credit(int amount)
        {
            Bsalary += amount;
        }
        public void Debit(int amount)
        {
            if (amount > Bsalary)
            {
                throw new Exception("Insuffient Funds");
            }
            Bsalary -= amount;
        }
    }

    class Ex07ClassesBasics
    {
        static void Main(string[] args)
        {
            Employee empobj = new Employee { EmpAddress = "Bangalore", EmpId = 111, EmpName = "Lekha", EmpSalary = 5000 };
            Console.WriteLine(empobj.EmpAddress);

            Account acc = new Account { AccountId = 111, Name = "Lekha" };
            Console.WriteLine(acc.Bsalary);

            acc.credit(1000);
            Console.WriteLine(acc.Bsalary);
            try
            {
                acc.Debit(3000);
                Console.WriteLine(acc.Bsalary);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
