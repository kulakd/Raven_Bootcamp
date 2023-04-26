using System;
using System.Reflection;
using Raven.Client;
using Raven.Client.Documents;
using Raven.Client.Documents.Indexes;
using Raven.Client.Documents.Session;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;
using Unit2_L3;

namespace MultimapIndexes
{
    public static class DocumentStoreHolder
    {
        private static readonly Lazy<IDocumentStore> LazyStore =
            new Lazy<IDocumentStore>(() =>
            {
                var store = new DocumentStore
                {
                    Urls = new[] { "http://localhost:8080" },
                    Database = "Northwind"
                };

                store.Initialize();

                var asm = Assembly.GetExecutingAssembly();
                IndexCreation.CreateIndexes(asm, store);

                var databaseRecord = store.Maintenance.Server.Send(new GetDatabaseRecordOperation(store.Database));

                if (databaseRecord != null)
                    return store;

                var createDatabaseOperation =
                    new CreateDatabaseOperation(new DatabaseRecord(store.Database));

                store.Maintenance.Server.Send(createDatabaseOperation);

                return store;
            });

        public static IDocumentStore Store =>
            LazyStore.Value;

        public static IEnumerable<People_Search.Result> Search(
    IDocumentSession session,
    string searchTerms
)
        {
            var results = session.Query<People_Search.Result, People_Search>()
                .Search(
                    r => r.Name,
                    searchTerms
                )
                .ProjectInto<People_Search.Result>()
                .ToList();

            return results;
        }
    }
}