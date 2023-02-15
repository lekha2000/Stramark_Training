using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsCsharp
{
    enum AccountType { SB, RD , FD };
    class AccountFactory
    {
        public static Account CreditType(AccountType acc)
        {
            switch (acc)
            {
                case AccountType.SB :
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
        public int Balance { get; private set; } = 12000000;
        public void Credit(int amt) => Balance += amt;
        public void Debit(int amt)
        {
            if(amt > Balance)
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
            var Prinicpal = Balance;
            var time = 0.25;
            var rate = 0.05;
            var intrest = Prinicpal * time * rate;
            Credit((int)intrest);
            Console.WriteLine("The current Balance is " + Balance);
            Console.WriteLine("The current Intrest is " + intrest);

        }

    }
