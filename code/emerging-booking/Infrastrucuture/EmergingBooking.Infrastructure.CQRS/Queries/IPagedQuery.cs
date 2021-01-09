namespace EmergingBooking.Infrastructure.Cqrs.Queries
{
    public interface IPagedQuery<in TPagedQueryParameters>
        where TPagedQueryParameters : PagingParameters
    {
    }
}
