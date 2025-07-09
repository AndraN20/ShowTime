using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories.Abstractions
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<IEnumerable<Genre>> GetAllWithArtists();
        Task<IList<Genre>> GetByIdsAsync(IEnumerable<int> ids);
    }
}
