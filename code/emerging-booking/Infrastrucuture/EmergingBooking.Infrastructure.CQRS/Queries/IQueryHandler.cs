using System.Threading.Tasks;

namespace EmergingBooking.Infrastructure.Cqrs.Queries
{
    public interface IQueryHandler<in TQueryParameters, TResult>
        where TQueryParameters : IQuery
    {
        Task<TResult> ExecuteQueryAsync(TQueryParameters queryParameters);
    }
}
