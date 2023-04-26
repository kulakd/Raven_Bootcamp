using Raven.Client.Documents;
using static Unit2_L2.Index;
using Unit2_L2;
using static Unit2_L2.Models;

class Program
{
    static void Main()
    {
        var store = DocumentStoreHolder.Store;
        new Employees_ByFirstAndLastName().Execute(store);
        using (var session = DocumentStoreHolder.Store.OpenSession())
        {
            var results = session
                .Query<Employee, Employees_ByFirstAndLastName>()
                .Where(x => x.FirstName == "Robert")
                .ToList();

            foreach (var employee in results)
            {
                Console.WriteLine($"{employee.LastName}, {employee.FirstName}");
            }
        }
    }
}