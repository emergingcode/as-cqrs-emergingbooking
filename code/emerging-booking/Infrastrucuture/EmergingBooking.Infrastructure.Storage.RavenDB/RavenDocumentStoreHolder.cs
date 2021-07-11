﻿using System;

using Microsoft.Extensions.Options;

using Raven.Client.Documents;

namespace EmergingBooking.Infrastructure.Storage.RavenDB
{
    internal class RavenDocumentStoreHolder : IRavenDocumentStoreHolder
    {
        private readonly Lazy<IDocumentStore> _documentStore;

        public RavenDocumentStoreHolder(
            IOptions<RavenDBSettings> optionsDatabaseSettings,
            Lazy<IDocumentStore> documentStore)
        {
            _documentStore = documentStore;
        }

        public IDocumentStore Store => _documentStore.Value;
    }
}