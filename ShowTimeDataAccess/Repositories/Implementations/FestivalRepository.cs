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

        public async Task<IEnumerable<Artist>> GetArtistsForFestivalAsync(int festivalId)
        {
            var festival = await _context.Festivals
                .Include(f => f.Artists)
                .FirstOrDefaultAsync(f => f.Id == festivalId);

            if (festival == null)
            {
                throw new KeyNotFoundException($"Festival with ID {festivalId} not found.");
            }

            return festival.Artists;
        }
    }
}
