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
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }

        public async Task<Booking?> GetByIdAsync(int festivalId, int userId)
        {
            return await _context.Bookings
                .Include(b => b.Festival)
                .FirstOrDefaultAsync(b => b.FestivalId == festivalId && b.UserId == userId);
        }

        public async Task DeleteAsync(int festivalId, int userId)
        {
            var booking = await _context.Bookings
                .FirstOrDefaultAsync(b => b.FestivalId == festivalId && b.UserId == userId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        public override async Task<Booking> UpdateAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

    }
}
