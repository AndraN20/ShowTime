using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories.Abstractions
{
    public interface IFestivalRepository : IRepository<Festival>
    {
        Task<IEnumerable<Artist>> GetArtistsForFestivalAsync(int festivalId);


    }
}
