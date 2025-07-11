using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.DataAccess.Repositories.Implementations
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(ShowTimeDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Booking>> GetBookingsForUserAsync(int userId)
        {
            return await _context.Bookings
                .Include(b => b.Festival)
                .Include(b => b.Ticket)
                .Include(b => b.User)
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsForFestivalAsync(int festivalId)
        {
            return await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Ticket)
                .Include(b => b.User)
                .Where(b => b.FestivalId == festivalId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.Festival)
                .Include(b => b.Ticket)
                .Include(b => b.User)
                .ToListAsync();
        }


        public async Task<Booking?> GetBookingAsync(int userId, int festivalId, int ticketId)
        {
            return await _context.Bookings
                .Include(b => b.Ticket)
                .Include(b => b.Festival)
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.UserId == userId && b.FestivalId == festivalId && b.TicketId == ticketId);
        }

        public async Task DeleteAsync(int userId, int festivalId, int ticketId)
        {
            var booking = await GetBookingAsync(userId, festivalId, ticketId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<int> GetTotalBookedQuantityForTicketAsync(int ticketId)
        {
            return await _context.Bookings
                .Where(b => b.TicketId == ticketId)
                .SumAsync(b => b.Quantity);
        }

    }
}
