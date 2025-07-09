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


        public async Task<IEnumerable<Lineup>> GetLineupsForFestivalAsync(int festivalId)
        {
            return await _context.Lineups
                .Where(l => l.FestivalId == festivalId)
                .Include(l => l.Artist)
                .ToListAsync();
        }
        public async Task<Lineup?> GetAsync(int festivalId, int artistId)
        {
            return await _context.Lineups
                .FirstOrDefaultAsync(l => l.FestivalId == festivalId && l.ArtistId == artistId);
        }

        public async Task DeleteAsync(int festivalId, int artistId)
        {
            var entity = await _context.Lineups.FindAsync(festivalId, artistId);
            if (entity == null)
                throw new KeyNotFoundException("Lineup not found");

            _context.Lineups.Remove(entity);
            await _context.SaveChangesAsync();
        }




    }
}
