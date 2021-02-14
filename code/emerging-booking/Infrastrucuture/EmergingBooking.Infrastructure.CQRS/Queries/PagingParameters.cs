namespace EmergingBooking.Infrastructure.Cqrs.Queries
{
    public class PagingParameters
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string SortOrder { get; set; }
        public string SortingColumn { get; set; }
    }
}
