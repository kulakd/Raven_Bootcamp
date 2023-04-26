﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit2_L3
{
    public class Models
    {
        public class Employee
        {
            public string Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class Contact
        {
            public string Name { get; set; }
        }

        public class Company
        {
            public string Id { get; set; }
            public Contact Contact { get; set; }
        }

        public class Supplier
        {
            public string Id { get; set; }
            public Contact Contact { get; set; }
        }

    }
}
