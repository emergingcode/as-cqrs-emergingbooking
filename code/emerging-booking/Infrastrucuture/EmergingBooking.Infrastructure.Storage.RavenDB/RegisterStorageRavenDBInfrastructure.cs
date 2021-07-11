using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Raven.Client.Documents;
using Raven.Client.Json.Serialization.NewtonsoftJson;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;

namespace EmergingBooking.Infrastructure.Storage.RavenDB
{
    public static class RegisterStorageRavenDBInfrastructure
    {
        public static IServiceCollection RegisterRavenDBStorageInfrastructureDependencies(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddOptions<RavenDBSettings>()
                    .Bind(configuration.GetSection(nameof(RavenDBSettings)));

            services.AddSingleton<Lazy<IDocumentStore>, Lazy<IDocumentStore>>(provider =>
            new Lazy<IDocumentStore>(
                () =>
                {
                    var _ravenSettings = provider.GetRequiredService<IOptions<RavenDBSettings>>().Value;

                    var store = new DocumentStore
                    {
                        Urls = new[] { _ravenSettings.Server },
                        Database = _ravenSettings.DatabaseName,
                        Conventions =
                        {
                            Serialization = new NewtonsoftJsonSerializationConventions
                            {
                                CustomizeJsonSerializer = serializer =>
                                {
                                    serializer.TypeNameHandling =
                                        Newtonsoft.Json.TypeNameHandling.Auto;
                                }
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
                }));

            services.AddSingleton<IRavenDocumentStoreHolder, RavenDocumentStoreHolder>();

            return services;
        }
    }
}