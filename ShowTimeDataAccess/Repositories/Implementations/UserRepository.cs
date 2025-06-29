using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(ShowTimeDbContext context) : base(context)
        {
        }
    }
}
