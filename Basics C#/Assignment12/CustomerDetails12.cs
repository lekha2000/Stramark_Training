using System;
using System.IO;

namespace Assignment12
{
    class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerAge { get; set; }
        public string CustomerAddress  { get; set; }
        
    }
    class CustomerManage
    {
        //Student is the type of array , std is the name of array
        // int[] arr = null i.e, student is the type of array 
        private Customer[] ctd = null;
        private int Size = 0;

        //Constructor for class
        public CustomerManage(int size)
        {
            Size = size;
            ctd = new Customer[Size];
        }

        //Function to Add student details
        //Passing student array and object
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
            Console.WriteLine(Ctd.CustomerId);
        }

        //Function to Update Student Details
        //Passing student array and object
        //std[i].StdID array id passed to std
        //Std.StdID user entered id passed to Std
        public void UpdateCtdDetails(Customer Ctd)
        {
            for (int i = 0; i < Size; i++)
            {
                //Checks if array not null and array i should match with user input i
                if (ctd[i] != null && ctd[i].CustomerId == ctd.CustomerId)
                {
                    ctd[i].CustomerId = Ctd.CustomerId;
                    ctd[i].CustomerName = Ctd.CustomerName;
                    ctd[i].CustomerAge = Ctd.CustomerAge;
                    ctd[i].CustomerAddress = Ctd.CustomerAddress;
                    return;
                }
            }
            throw new Exception("Student ID not found to Update");
        }

        //Function to Find Student Details based on id 
        public Customer FindCustomer(int id)
        {
            foreach (Customer i in ctd)
            {
                if (i != null && i.CustomerId == id)
                    return i;
            }
            throw new Exception("No Account found");

        }

        //Function To Delete Student Details based on id
        //std[i].StdID array id passed to std
        //Std.StdID user entered id passed to Std
        public void DeleteCustomer(int id)
        {
            for (int i = 0; i < Size; i++)
            {
                //Checks if array not null and array i should match with user input i
                if (ctd[i] != null && ctd[i].CustomerId == id)
                {
                    ctd[i] = null;
                    Console.WriteLine($"The Details of the Student with id {id} has been deleted "); ;
                }
            }
            throw new Exception("No Account found to delete");
        }
    }
}
