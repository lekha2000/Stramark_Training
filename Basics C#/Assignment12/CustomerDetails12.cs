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
    class UIStudent
    {
        public static CustomerManage msg = null;

        public static void DisplayMenu()
        {
            Console.WriteLine("Enter the Size : ");
            int size = Convert.ToInt32(Console.ReadLine());
            msg = new CustomerManage(size);
            bool process = true;

            do
            {
                Console.WriteLine("==================Customer Management System===================");
                Console.WriteLine("1...............Add Customer Record");
                Console.WriteLine("2...............Modify Customer Record");
                Console.WriteLine("3...............Find Customer Record");
                Console.WriteLine("4...............Delete Customer Record");
                Console.WriteLine("5...............Exit");
                Console.Write("Select option (between 1 to 5) : ");

                int option = Convert.ToInt32(Console.ReadLine());
                process = ProcessMenu(option);

            } while (process);
            Console.WriteLine("Thanks for using our application");
        }

        private static bool ProcessMenu(int option)
        {
            switch (option)
            {
                case 1:
                    addingCustomerHelper();
                    break;
                case 2:
                    updatingCustomerHelper();
                    break;
                case 3:
                    findingCustomerHelper();
                    break;
                case 4:
                    deleteCustomerHelper();
                default:
                    return false;
            }
            return true;
        }

        private static void addingCustomerHelper()
        {
            Console.Write("Enter the Id of Customer : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Name of Customer : ");
            string name = Console.ReadLine();
            Console.Write("Enter the Date Of Age of Customer : ");
            int Age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Address of Customer : ");
            string Address = Console.ReadLine();

            Student ctd = new Customer
            {
                CustomerID = id,
                CustomerName = name,
                CustomerAge = Age,
                CustomerAddress = Address,
            };
            msg.AddCtdDetails(ctd);
            Console.WriteLine(ctd.CustomerId);
            Console.Write("Customer Details Added Succesfully");

            //Console.WriteLine("Press Enter to Clear the Screen");
            //Console.Clear();
        }

        private static void updatingCustomerHelper()
        {
            Console.Write("Enter the Id of Customer : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Name of Customer : ");
            string name = Console.ReadLine();
            Console.Write("Enter the Date Of Age of Customer : ");
            int Age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Address of Customer : ");
            string Address = Console.ReadLine();

            Student ctd = new Customer
            {
                CustomerID = id,
                CustomerName = name,
                CustomerAge = Age,
                CustomerAddress = Address,
            };

            msg.UpdateCtdDetails(ctd);
            Console.WriteLine("Press Enter to Clear the Screen");
            Console.Clear();
        }

        private static void findingCustomerHelper()
        {
            Console.Write("Enter the Id of Customer : ");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                Student ctd = msg.FindCustomer(id);
                Console.WriteLine("The Details of the Student are as follows:");
                string content = $"\nThe Student No: {ctd.CustomerId}\nThe Name: {ctd.CustomerName}\nThe Age : {ctd.CustomerAge}\nThe Address : {ctd.CustomerAddress}\n";
                Console.WriteLine(content);
                Console.WriteLine("Press Enter to Clear the Screen");
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void deleteCustomerHelper()
        {
            Console.Write("Enter the Id of Customer : ");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                Student ctd = msg.DeleteCustomer(id);
                Console.WriteLine("Press Enter to Clear the Screen");
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    class Assignment12
    {
        static void Main(string[] args)
        {
            UIStudent.DisplayMenu();
        }
    }
}
