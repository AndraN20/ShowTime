using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories.Abstractions
{
    public interface ILineupRepository : IRepository<Lineup>
    {
        Task<IEnumerable<Lineup>> GetLineupsForArtistAsync(int artistId);
        Task<IEnumerable<Lineup>> GetLineupsForFestivalAsync(int festivalId);

    }
}
