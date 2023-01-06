using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Account1
    {
        public int AccountNo { get; set; }
        public string AccountName { get; set; }
        public int Balance { get; protected set; } = 75000;
    }

    class SBAccount : Account1
    {
        public void Credit(int amount) => Balance += amount;

        public void Debit(int amount) => Balance -= amount;

    }

    //
    class RDAccount : Account1
    {
        int amount = 5000;
        public void MakePayment()
        {
            Console.WriteLine($"Payment of Rs. {amount} is done");
            Balance += amount;
        }
    }

    class Ex09_Inheritance
    {
        static void Main(string[] args)
        {
            Account1 a = new Account1();
            SBAccount acc = new SBAccount { AccountName = "testName", AccountNo = 123 };
            Console.WriteLine("\nBalance in Account : " + a.Balance + "\n");
            int credit = 45000;
            Console.WriteLine("Amount to be Cretited " + credit );
            acc.Credit(credit);
            Console.WriteLine("Balance in Account After The Credit : " + acc.Balance + "\n");
            int debit = 5000;
            Console.WriteLine("Amount to be Debited " + debit);
            acc.Debit(debit);
            Console.WriteLine("Balance in Account After The Debit : " + acc.Balance + "\n");
        }

    }
}
