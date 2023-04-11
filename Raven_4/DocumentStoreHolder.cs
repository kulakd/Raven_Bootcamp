using Raven.Client.Documents;
using Raven.Client.ServerWide.Operations;
using Raven.Client.ServerWide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven_4
{
    public static class DocumentStoreHolder
    {

        private static readonly Lazy<IDocumentStore> LazyStore =
             new Lazy<IDocumentStore>(() =>
             {
                 var store = new DocumentStore
                 {
                     Urls = new[] { "http://localhost:8080" },
                     Database = "ContactsManager"
                 };
                 store.Initialize();

                 // Try to retrieve a record of this database
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
    }
}
