using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories.Abstractions
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetBookingsForUserAsync(int userId);
        Task<Booking?> GetByIdAsync(int festivalId, int userId);
        Task DeleteAsync(int festivalId, int userId);
    }
}
