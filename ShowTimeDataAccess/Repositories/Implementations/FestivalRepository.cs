using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.DataAccess.Repositories.Implementations
{
    public class FestivalRepository : BaseRepository<Festival>, IFestivalRepository
    {
        public FestivalRepository(ShowTimeDbContext context) : base(context)
        {
        }
    }
}
