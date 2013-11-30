using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mustache_CSharp
{
    public class Order
    {
        public List<Item> LineItems { get; set; }
        public int Total { get; set; }
    }

    public class Item
    {
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }   
    }
}
