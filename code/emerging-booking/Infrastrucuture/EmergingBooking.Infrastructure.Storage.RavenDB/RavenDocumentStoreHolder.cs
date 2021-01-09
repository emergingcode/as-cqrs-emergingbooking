using System;
using Microsoft.Extensions.Options;
using Raven.Client.Documents;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;

namespace EmergingBooking.Infrastructure.Storage.RavenDB
{
    internal class RavenDocumentStoreHolder : IRavenDocumentStoreHolder
    {
        private readonly RavenDBSettings _ravenSettings;

        public RavenDocumentStoreHolder(IOptions<RavenDBSettings> optionsDatabaseSettings)
        {
            _ravenSettings = optionsDatabaseSettings.Value;
        }

        private Lazy<IDocumentStore> LazyStore => 
            new Lazy<IDocumentStore>(() =>
            {
                var store = new DocumentStore
                {
                    Urls = new[] {_ravenSettings.Server},
                    Database = _ravenSettings.DatabaseName,
                    Conventions =
                    {
                        CustomizeJsonSerializer = serializer =>
                        {
                            serializer.TypeNameHandling =
                                Newtonsoft.Json.TypeNameHandling.Auto;
                        }
                    }
                };


                store.Initialize();

                // Try to retrieve a record from this database, inside of internal system databases
                var databaseRecord =
                    store.Maintenance.Server.Send(new GetDatabaseRecordOperation(store.Database));

                if (databaseRecord != null)
                    return store;

                var createDatabaseOperation =
                    new CreateDatabaseOperation(new DatabaseRecord(store.Database));

                store.Maintenance.Server.Send(createDatabaseOperation);

                return store;
            });
        

        public IDocumentStore Store => LazyStore.Value;
    }
}
