using Raven.Client.Documents.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Unit2_L2.Models;

namespace Unit2_L2
{
    public class Index
    {
        public class Employees_ByFirstAndLastName : AbstractIndexCreationTask<Employee>
        {
            public Employees_ByFirstAndLastName()
            {
                Map = (employees) =>
                    from employee in employees
                    select new
                    {
                        FirstName = employee.FirstName,
                        LastName = employee.LastName
                    };
            }
        }
    }
}
