using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories.Implementations
{
    public class FestivalRepository : BaseRepository<Festival>
    {
        public FestivalRepository(ShowTimeDbContext context) : base(context)
        {
        }
    }
}
