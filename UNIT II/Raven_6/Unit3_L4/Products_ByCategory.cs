using Raven.Client.Documents.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Unit3_L4.Model;

namespace Unit3_L4
{
    public class ProductsByCategory :
    AbstractIndexCreationTask<Product, ProductsByCategory.Result>
    {
        public class Result
        {
            public string Category { get; set; }
            public int Count { get; set; }
        }

        public ProductsByCategory()
        {
            Map = products =>
            from product in products
            let categoryName = LoadDocument<Category>(product.Category).Name
            select new
            {
                Category = categoryName,
                Count = 1
            };

            Reduce = results =>
                from result in results
                group result by result.Category into g
                select new
                {
                    Category = g.Key,
                    Count = g.Sum(x => x.Count)
                };
        }
    }
}
