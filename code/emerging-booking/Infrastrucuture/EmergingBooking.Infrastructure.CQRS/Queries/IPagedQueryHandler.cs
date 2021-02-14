using System.Threading.Tasks;

namespace EmergingBooking.Infrastructure.Cqrs.Queries
{
    public interface IPagedQueryHandler<in TPagedQueryParameters, TResult>
        where TPagedQueryParameters : IPagedQuery<PagingParameters>
    {
        Task<TResult> ExecuteQueryAsync(TPagedQueryParameters queryParameters);
    }
}
