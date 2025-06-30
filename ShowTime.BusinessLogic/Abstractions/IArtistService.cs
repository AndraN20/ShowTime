using ShowTime.BusinessLogic.DTOs;
using ShowTime.DataAccess.Models;

namespace ShowTime.BusinessLogic.Abstractions
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistGetDto>> GetAllArtistsAsync();
        Task<ArtistGetDto> GetArtistByIdAsync(int id);
        Task<ArtistGetDto> CreateArtistAsync(ArtistCreateDto artistDto);
        Task<ArtistGetDto> UpdateArtistAsync(int id, ArtistUpdateDto artistDto);
        Task DeleteArtistAsync(int id);
    }
}
