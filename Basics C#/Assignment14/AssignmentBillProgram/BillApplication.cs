using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace AssignmentBillProgram
{
    class Bill
    {
        public int BillNo { get; set; }
        public int BillAmount { get; set; }
        public string BillholderName { get; set; }

        public void GenrateDate()
        {
            DateTime date = DateTime.Now;
            Console.Write("Dated : ");
            Console.Write(date.ToShortDateString());
            Console.WriteLine();
        }
        public int generateId()
        {
            Random random = new Random();
            int id = random.Next(52);
            Console.Write("Bill No : ");
            Console.Write(id + "\n");
            return id;

        }

    }
    class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; } = 1;
        public int ItemAmount { get; set; }

        public override int GetHashCode()
        {
            return ItemID.GetHashCode();
        }
