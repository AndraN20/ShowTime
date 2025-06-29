using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories.Implementations
{
    public class BookingRepository : BaseRepository<Booking>
    {
        public BookingRepository(ShowTimeDbContext context) : base(context)
        {
        }
    }
}
