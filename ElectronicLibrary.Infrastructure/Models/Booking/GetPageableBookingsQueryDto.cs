using ElectronicLibrary.Infrastructure.Extensions;

namespace ElectronicBookingSystem.Infrastructure.Models.Booking
{
    public class GetPageableBookingsQueryDto : IPageableQueryModel
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string OrderBy { get; set; }
        public bool Desc { get; set; }
        public string SearchTerm { get; set; }
    }
}
