using System;
using System.Threading.Tasks;
using EmergingBooking.Infrastructure.Cqrs.Commands;

namespace EmergingBooking.Infrastructure.Cqrs.Queries
{
    internal class QueryProcessor : IQueryProcessor
    {
        private readonly DependencyResolver _dependencyResolver;

        public QueryProcessor(DependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        public async Task<TResult> ExecuteQueryAsync<TQueryParameters, TResult>(
            TQueryParameters queryParameters)
                where TQueryParameters : IQuery
        {
            if (queryParameters == null)
                throw new ArgumentNullException(nameof(queryParameters));

            var queryHandler = _dependencyResolver.Resolve<IQueryHandler<TQueryParameters, TResult>>();

            return await queryHandler.ExecuteQueryAsync(queryParameters);
        }

        public async Task<TResult> ExecutePagedQueryAsync<TPagedQueryParameters, TResult>(
            TPagedQueryParameters pagingQueryParameters)
                where TPagedQueryParameters : IPagedQuery<PagingParameters>
        {
            if (pagingQueryParameters == null)
                throw new ArgumentNullException(nameof(pagingQueryParameters));

            var queryHandler = _dependencyResolver.Resolve<IPagedQueryHandler<TPagedQueryParameters, TResult>>();

            return await queryHandler.ExecuteQueryAsync(pagingQueryParameters);
        }
    }
}
