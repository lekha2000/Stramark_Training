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
        public override bool Equals(object obj)
        {
            if (obj is Item)
            {
                var unBoxed = obj as Item;
                if (ItemID == unBoxed.ItemID && ItemName == unBoxed.ItemName && ItemQuantity == unBoxed.ItemQuantity && ItemAmount == unBoxed.ItemAmount) ;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{ItemID} \t {ItemName} \t {ItemQuantity}  \t {ItemAmount}";
        }
    }
