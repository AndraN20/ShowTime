using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories.Abstractions
{
    public interface ILineupRepository : IRepository<Lineup>
    {
        Task<IEnumerable<Lineup>> GetLineupsForFestivalAsync(int festivalId);
        Task<Lineup?> GetAsync(int festivalId, int artistId);
        Task DeleteAsync(int festivalId, int artistId);
    }
}
