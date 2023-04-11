using System;
using System.Linq;
using static System.Console;
using Raven.Client.Documents;
using static Raven_3.NorthwindModel;

namespace Raven_3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                WriteLine("Please, enter a company id (0 to exit): ");

                if (!int.TryParse(ReadLine(), out var companyId))
                {
                    WriteLine("Company # is invalid.");
                    continue;
                }

                if (companyId == 0) break;

                QueryCompanyOrders(companyId);
            }

            WriteLine("Goodbye!");
        }

        private static void QueryCompanyOrders(int companyId)
        {
            string companyReference = $"companies/{companyId}-A";

            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                var orders = session.Advanced.RawQuery<Order>(
                    "from Orders " +
                    "where Company== $companyId " +
                    "include Company"
                ).AddParameter("companyId", companyReference)
                .ToList();

                var company = session.Load<Company>(companyReference);

                if (company == null)
                {
                    WriteLine("Company not found.");
                    return;
                }

                WriteLine($"Orders for {company.Name}");

                foreach (var order in orders)
                {
                    WriteLine($"{order.Id} - {order.OrderedAt}");
                }
            }
        }
    }
}