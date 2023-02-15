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
