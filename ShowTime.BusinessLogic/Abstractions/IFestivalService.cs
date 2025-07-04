using ShowTime.BusinessLogic.DTOs.Festival;

namespace ShowTime.BusinessLogic.Abstractions
{
    public interface IFestivalService
    {
        Task<IList<FestivalGetDto>> GetAllFestivalsAsync();
        Task<FestivalGetDto> GetFestivalByIdAsync(int id);
        Task<FestivalGetDto> CreateFestivalAsync(FestivalCreateDto artistDto);
        Task<FestivalGetDto> UpdateFestivalAsync(int id, FestivalUpdateDto artistDto);
        Task DeleteFestivalAsync(int id);
        Task<IList<FestivalGetDto>> GetFestivalsForArtistAsync(int id);
    }
}
