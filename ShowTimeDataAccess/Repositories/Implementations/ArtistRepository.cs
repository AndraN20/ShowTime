using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.DataAccess.Repositories.Implementations
{
    public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(ShowTimeDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Artist>> GetAllByFestivalAsync(int id)
        {
            return await _context.Artists
                .Where(f => f.Lineups.Any(p => p.FestivalId == id))
                .ToListAsync();
        }
    }
}
