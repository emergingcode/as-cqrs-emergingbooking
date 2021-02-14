using Raven.Client.Documents;

namespace EmergingBooking.Infrastructure.Storage.RavenDB
{
    public interface IRavenDocumentStoreHolder
    {
        IDocumentStore Store { get; }
    }
}