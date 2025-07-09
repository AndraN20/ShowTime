using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.DataAccess.Repositories.Implementations
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ShowTimeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Genre>> GetAllWithArtists()
        {
            return await _context.Genres
                .Include(l => l.Artists).ToListAsync();
        }

        public async Task<IList<Genre>> GetByIdsAsync(IEnumerable<int> ids)
        {
            try
            {
                if (ids == null || !ids.Any())
                {
                    return new List<Genre>();
                }
                return await _context.Genres
                    .Where(g => ids.Contains(g.Id))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting genres by ids", ex);
            }
        }
    }
}
