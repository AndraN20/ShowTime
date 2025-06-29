using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories.Implementations
{
    public class LineupRepository : BaseRepository<Lineup>
    {
        public LineupRepository(ShowTimeDbContext context) : base(context)
        {
        }
    }
}
