using System;

namespace AssignmentFunction
{
    enum AccountType { SB, RD, FD };
    class AccountFactory
    {
        public static Account CreditType(AccountType acc)
        {
            switch (acc)
            {
                case AccountType.SB:
                    return new SBAccount();

                case AccountType.FD:
                    return new FDAccount();

                case AccountType.RD:
                    return new RDAccount();
                default:
                    throw new Exception("Please Enter Correct Account Type");
            }
        }
    }
    abstract class Account
    {
        public int AccNo { get; set; }
        public string Name { get; set; }
        public int Balance { get; private set; } = 1000000;
        public void Credit(int amt) => Balance += amt;
        public void Debit(int amt)
        {
            if (amt > Balance)
            {
                throw new Exception("Insufficient Funds");
            }
            Balance -= amt;
        }
        public abstract void CalculateIntrest();
    }
    class SBAccount : Account
    {
        public override void CalculateIntrest()
        {
            var Principal = Balance;
            var time = 0.25;
            var rate = 0.05;
            var intrest = Principal * time * rate;
            Credit((int)intrest);
            Console.WriteLine("The current Balance is " + Balance + "Rs");
            Console.WriteLine("\nThe current Intrest is " + intrest + "Rs");

        }

    }
    class FDAccount : Account
    {
        public override void CalculateIntrest()
        {
            //Compound Interest = Principal * (1 + (rate / numberofyears) * numberofyears * time) - Prinicpal
            //= 10,00,000 (1 + 0.06/1)1 x 5 - 10,00,000
            //= 13,38,226 - 10,00,000
            //= ₹3,38,226
            var Principal = Balance;
            var time = 5;
            var rate = 0.06;
            var numberofyears = 1;
            var result = Principal * (1 + (rate / numberofyears) * numberofyears * time) - Principal;

            var MaturityAmount = result;
            Credit((int)MaturityAmount);
            Console.WriteLine("The current balance is " + Balance + "Rs");
            Console.WriteLine("The current Maturity Amount is " + MaturityAmount + "Rs");
        }
    }
    class RDAccount : Account
    {
        public override void CalculateIntrest()
        {
            //Compound Interest = Principal amount (1 + InterestRate/Years) * (Years * number of times). 
            var Principal = Balance;
            var time = 3;
            var rate = 0.0825;
            var numberofyears = 4;
            var value = numberofyears * time;
            var result = Principal * (1 + (rate / numberofyears) * value);

            var Amount = result;
            Credit((int)Amount);
            Console.WriteLine("The current balance is " + Balance + "Rs");
            Console.WriteLine("The current Amount is " + Amount + "Rs");
        }
    }

    class Abstract
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Account Type: ");
            string type = Console.ReadLine();

            Account acc = AccountFactory.CreditType((AccountType)Enum.Parse(typeof(AccountType), type));
            acc.CalculateIntrest();

            /*Account acc = new SBAccount();
            acc.AccNo = 123;
            acc.Name = "Lekha";
            acc.Credit(56000);
            acc.CalculateIntrest();
            Console.WriteLine("The current balance is " + acc.Balance);*/
        }


    }
}