using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.DataAccess.Repositories.Implementations
{
    public class FestivalRepository : BaseRepository<Festival>, IFestivalRepository
    {
        public FestivalRepository(ShowTimeDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Festival>> GetAllByArtistAsync(int id)
        {
            return await _context.Festivals
                .Where(f => f.Lineups.Any(p => p.ArtistId == id))
                .ToListAsync();
        }
    }
}
