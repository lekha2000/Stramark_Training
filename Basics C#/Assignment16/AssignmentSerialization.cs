using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Utility;

namespace Sampleframeworkapps
{
    public class Customer
    {
        public int CustomerId;
        public string CustomerName;
        public string CustomerAddress;
        public long CustomerPhoneNo;
        public int BillAmt;
        public override string ToString()
        {
            return $"{CustomerId}\t{CustomerName}\t{CustomerAddress}\t{CustomerPhoneNo}\t{BillAmt}";
        }
    }
    class AssignmentSerialization
    {
        
        public static void AddCustomer()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer {
                CustomerId = 1,
                CustomerName = "Lekha",
                CustomerAddress = "Nodia",
                CustomerPhoneNo = 7856349020,
                BillAmt = 50000
            });
            customers.Add(new Customer
            {
                CustomerId = 2,
                CustomerName = "Sneha",
                CustomerAddress = "Punjab",
                CustomerPhoneNo = 9956349020,
                BillAmt = 70000
            });
            customers.Add(new Customer
            {
                CustomerId = 3,
                CustomerName = "Nihkil",
                CustomerAddress = "Gujarat",
                CustomerPhoneNo = 8056349020,
                BillAmt = 15000
            });
            customers.Add(new Customer
            {
                CustomerId = 4,
                CustomerName = "Mahesh",
                CustomerAddress = "Delhi",
                CustomerPhoneNo = 7656349020,
                BillAmt = 90000
            });
            customers.Add(new Customer
            {
                CustomerId = 5,
                CustomerName = "Alisha",
                CustomerAddress = "Ladhak",
                CustomerPhoneNo = 8700672978,
                BillAmt = 40000
            });
            customers.Add(new Customer
            {
                CustomerId = Utilities.GetNumber("\nEnter the Customer ID"),
                CustomerName = Utilities.Prompt("Enter the Customer name"),
                CustomerAddress = Utilities.Prompt("Enter the Customer Address"),
                CustomerPhoneNo = Utilities.GetPNumber("Enter the Customer PhoneNumber"),
                BillAmt = Utilities.GetNumber("Enter the Bill Amount"),

            });

            FileStream fs = new FileStream("customer.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Customer>));
            xmlSer.Serialize(fs, customers);
            fs.Close();
            Console.WriteLine();
        }
        private static void UpdateDetails()
        {
            int id = Utilities.GetNumber("\nEnter the Customer ID");
            List<Customer> cst ;
            FileStream fs = new FileStream("customer.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer des = new XmlSerializer(typeof(List<Customer>));
            cst = des.Deserialize(fs) as List<Customer>;
            fs.Close();
            foreach (var item in cst)
            {
                //Console.WriteLine(item);
                if (item.CustomerId == id)
                {
                    Console.WriteLine($"Customer With {id} Found\n");
                    item.CustomerId = id;
                    item.CustomerName = Utilities.Prompt("Enter the Customer name");
                    item.CustomerAddress = Utilities.Prompt("Enter the Customer Address");
                    item.CustomerPhoneNo = Utilities.GetPNumber("Enter the Customer PhoneNumber");
                    item.BillAmt = Utilities.GetNumber("Enter the Bill Amount");
                   
                    
                }
                else
                {
                    //Console.WriteLine($"Customer With {id} Not Found");
                }
            }
            
            FileStream fss = new FileStream("customer.xml", FileMode.Open, FileAccess.Write);
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Customer>));
            xmlSer.Serialize(fss, cst);
            fss.Close();
            Console.WriteLine("Customer Details Updated successfully");
            Console.WriteLine();
        }
        public static void FindCustomer()
        {
            int id = Utilities.GetNumber("\nEnter the Customer ID");
            List<Customer> cst = null;
            FileStream fs = new FileStream("customer.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer des = new XmlSerializer(typeof(List<Customer>));
            cst = des.Deserialize(fs) as List<Customer>;
            fs.Close();
            foreach (var item in cst)
            {
                if (item.CustomerId == id)
                {
                    Console.WriteLine($"Customer With {id} Found\n");
                    Console.WriteLine(item);
                }
                else
                {
                    //Console.WriteLine($"Customer With {id} Not Found");
                }
            }
            
        }
        public static void DisplayCustomer()
        {
            List<Customer> cst ;
            FileStream fs = new FileStream("customer.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer des = new XmlSerializer(typeof(List<Customer>));
            cst = des.Deserialize(fs) as List<Customer>;
            fs.Close();
            foreach (var item in cst)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
        public static void Deletecustomer()
        {
            
            List<Customer> cst;
            FileStream fs = new FileStream("customer.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer des = new XmlSerializer(typeof(List<Customer>));
            cst = des.Deserialize(fs) as List<Customer>;
            fs.Close();
            int id = Utilities.GetNumber("\nEnter the Customer ID");
            foreach (var item in cst)
            {
                if (item.CustomerId == id)
                {
                    Console.WriteLine(item);
                    cst.Remove(item);
                    Console.WriteLine($"Customer With {id} Deleted Successfully");
                   
                    
                }
                
            }
            FileStream fss = new FileStream("customer.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Customer>));
            xmlSer.Serialize(fss, cst);
            fss.Close();
            Console.WriteLine();
            return;

        }

      
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("----------------Customer Information----------------");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("----------Press 1 To Add Customer Details-----------\n" +
                                  "----------Press 2 To Update Customer Details--------\n" +
                                  "----------Press 3 To Find Customer Details----------\n" +
                                  "----------Press 4 To Display Customer Details-------\n" +
                                  "----------Press 5 To Delete Customer Details--------\n");
                Console.Write("Choice : ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddCustomer();
                        break;
                    case "2":
                        UpdateDetails();
                        break;
                    case "3":
                        FindCustomer();
                        break;
                    case "4":
                        DisplayCustomer();
                        break;
                    case "5":
                        Deletecustomer();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }          
        } 
    }
}
