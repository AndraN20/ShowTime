using ShowTime.BusinessLogic.DTOs.Artist;
using ShowTime.BusinessLogic.DTOs.Genre;

namespace ShowTime.BusinessLogic.Abstractions
{
    public interface IGenreService
    {
        Task<IList<GenreGetDto>> GetAllGenresAsync();
        Task<GenreGetDto> GetGenreByIdAsync(int id);
        Task<GenreGetDto> CreateGenreAsync(string genreName);
        Task DeleteAsync(int id);
        Task<IList<GenreGetDto>> GetGenresByIdsAsync(IList<int> ids);
    }
}
