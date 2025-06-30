using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.DataAccess.Repositories.Implementations
{
    public class LineupRepository : BaseRepository<Lineup>, ILineupRepository
    {
        public LineupRepository(ShowTimeDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Lineup>> GetLineupsForArtistAsync(int artistId)
        {
            return await _context.Lineups
                .Where(l => l.ArtistId == artistId)
                .Include(l => l.Festival)
                .ToListAsync();
        }

        public async Task<IEnumerable<Lineup>> GetLineupsForFestivalAsync(int festivalId)
        {
            return await _context.Lineups
                .Where(l => l.FestivalId == festivalId)
                .Include(l => l.Artist)
                .ToListAsync();
        }
    }
}
