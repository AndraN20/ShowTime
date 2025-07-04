using ShowTime.BusinessLogic.DTOs.Artist;
using ShowTime.BusinessLogic.DTOs.Festival;

namespace ShowTime.BusinessLogic.Abstractions
{
    public interface IArtistService
    {
        Task<IList<ArtistGetDto>> GetAllArtistsAsync();
        Task<ArtistGetDto> GetArtistByIdAsync(int id);
        Task<ArtistGetDto> CreateArtistAsync(ArtistCreateDto artistDto);
        Task<ArtistGetDto> UpdateArtistAsync(int id, ArtistUpdateDto artistDto);
        Task DeleteArtistAsync(int id);
        Task<IList<ArtistGetDto>> GetArtistsForFestivalAsync(int id);
    }
}
