using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.DataAccess.Repositories.Implementations
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(ShowTimeDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Ticket>> GetTicketsForFestivalAsync(int festivalId)
        {
            return await _context.Tickets
                .Where(t => t.FestivalId == festivalId)
                .ToListAsync();
        }

        public async Task<Ticket?> GetByNameAsync(int festivalId, string name)
        {
            return await _context.Tickets
                .FirstOrDefaultAsync(t => t.FestivalId == festivalId && t.Name == name);
        }
    }
}
