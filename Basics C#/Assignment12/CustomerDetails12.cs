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

        //A shallow copy of an object is a copy whose properties share the same references 
        //(point to the same underlying values) as those of the source object from which the copy was made.
        
    }
}
