using MultimapIndexes;

static void Main(string[] args)
{
    Console.Title = "Multi-map sample";
    using (var session = DocumentStoreHolder.Store.OpenSession())
    {
        while (true)
        {
            Console.Write("\nSearch terms: ");
            var searchTerms = Console.ReadLine();

            foreach (var result in DocumentStoreHolder.Search(session, searchTerms))
            {
                Console.WriteLine($"{result.SourceId}\t{result.Type}\t{result.Name}");
            }
        }
    }
}