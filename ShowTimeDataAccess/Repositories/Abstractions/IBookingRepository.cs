using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories.Abstractions
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetBookingsForUserAsync(int userId);
        Task<IEnumerable<Booking>> GetBookingsForFestivalAsync(int festivalId);
        Task<Booking?> GetBookingAsync(int userId, int festivalId, int ticketId);
        Task DeleteAsync(int userId, int festivalId, int ticketId);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<int> GetTotalBookedQuantityForTicketAsync(int ticketId);
    }
}
