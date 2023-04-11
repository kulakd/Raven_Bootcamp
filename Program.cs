using Raven.Client.Documents;
using System.Diagnostics;

namespace Raven
{
    class Program
    {
        static void Main()
        {
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                var p1 = session.Load<Product>("products/1-A");
                var p2 = session.Load<Product>("products/1-A");
                Debug.Assert(ReferenceEquals(p1, p2));
            }
            System.Console.WriteLine("Press <ENTER> to continue...");
            System.Console.ReadLine();
        }
    }
}