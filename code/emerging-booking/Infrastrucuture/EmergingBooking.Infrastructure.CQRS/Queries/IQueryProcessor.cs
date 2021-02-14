using System.Threading.Tasks;

namespace EmergingBooking.Infrastructure.Cqrs.Queries
{
    public interface IQueryProcessor
    {
        Task<TResult> ExecuteQueryAsync<TQueryParameters, TResult>(TQueryParameters queryParameters)
            where TQueryParameters : IQuery;

        Task<TResult> ExecutePagedQueryAsync<TPagedQueryParameters, TResult>(TPagedQueryParameters pagingQueryParameters)
            where TPagedQueryParameters : IPagedQuery<PagingParameters>;
    }
}