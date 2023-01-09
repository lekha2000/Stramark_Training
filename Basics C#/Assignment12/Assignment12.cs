using Assignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment12
{
  class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerAge { get; set; }
        public string CustomerAddress { get; set; }

    }
  class CustomerManage
    {
        private Customer[] ctd = null;
        private int Size = 0;

        //Constructor for class
        public CustomerManage(int size)
        {
            Size = size;
            ctd = new Customer[Size];
        }

        public void AddCtdDetails(Customer Ctd)
        {

            for (int i = 0; i < Size; i++)
            {
                if (ctd[i] == null)
                {
                    ctd[i] = new Customer
                    {
                        CustomerId = Ctd.CustomerId,
                        CustomerName = Ctd.CustomerName,
                        CustomerAge = Ctd.CustomerAge,
                        CustomerAddress = Ctd.CustomerAddress
                    };
                    return;
                }
            }
        }

