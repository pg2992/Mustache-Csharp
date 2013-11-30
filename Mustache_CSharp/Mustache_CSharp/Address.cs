using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace Mustache_CSharp
{
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

    }
}
