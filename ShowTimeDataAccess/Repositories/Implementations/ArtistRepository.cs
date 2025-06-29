using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories.Implementations
{
    public class ArtistRepository : BaseRepository<Artist>
    {
        public ArtistRepository(ShowTimeDbContext context) : base(context)
        {
        }
    }
}
