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
