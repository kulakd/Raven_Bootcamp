﻿using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven_3
{
    public static class DocumentStoreHolder
    {

        private static readonly Lazy<IDocumentStore> LazyStore =
            new Lazy<IDocumentStore>(() =>
            {
                var store = new DocumentStore()
                {
                    Urls = new[] { "http://localhost8080" },
                    Database = "Northwind"
                };
                return store.Initialize();
            });

        public static IDocumentStore Store => LazyStore.Value;
    }
}
