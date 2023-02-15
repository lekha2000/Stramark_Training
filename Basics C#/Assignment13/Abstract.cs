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
