using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit3_L4
{
    public class Model
    {
        public class Category
        {
            public string Name { get; set; }
        }

        public class Product
        { 
            public string Category { get; set; } 
        }
        public class Order
        {
            public string Employee { get; }
            public DateTime OrderedAt { get; }
        }

        public class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
