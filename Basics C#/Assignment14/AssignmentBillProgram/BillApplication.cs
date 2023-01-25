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
    class BillApplication
    {
        static Bill bill = new Bill();
        int TotalAmount = 0;
        static Item itm = new Item();
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();
            HashSet<Item> itembill = new HashSet<Item>();          
            Console.Write("Bill Holder Name : ");
            string name = Console.ReadLine();
            bill.BillholderName = name;
            Console.WriteLine();
        Console.WriteLine("---------List Of Items---------");
            HashSet<Item> item = new HashSet<Item>();
            item.Add(new Item { ItemID = 1, ItemName = "Idli", ItemAmount = 50 });
            item.Add(new Item { ItemID = 2, ItemName = "Dosa", ItemAmount = 30 });
            item.Add(new Item { ItemID = 3, ItemName = "Vada", ItemAmount = 20 });
            item.Add(new Item { ItemID = 4, ItemName = "Poori", ItemAmount = 100 });
            item.Add(new Item { ItemID = 5, ItemName = "Upama", ItemAmount = 40 });

            foreach (Item items in item)
            {
                Console.WriteLine(items.ToString());
            }
            Console.WriteLine();
