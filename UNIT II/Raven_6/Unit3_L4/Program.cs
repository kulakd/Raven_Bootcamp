using static Unit3_L4.Model;
using Unit3_L4;
using Raven.Client.Documents;

namespace Unit3_L4
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                var query = session.Query<ProductsByCategory.Result, ProductsByCategory>();
                //.Include(x => x.Category);

                var results = (
                    from result in query
                    select result
                    ).ToList();

                foreach (var result in results)
                {
                    //var category = session.Load<Category>(result.Category);
                    //Console.WriteLine($"{category.Name} has {result.Count} items.");
                    Console.WriteLine($"{result.Category} has {result.Count} items.");
                }
            }
        }
    }
}