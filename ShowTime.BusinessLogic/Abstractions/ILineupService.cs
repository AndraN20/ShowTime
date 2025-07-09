using ShowTime.BusinessLogic.DTOs.Lineup;

namespace ShowTime.BusinessLogic.Abstractions
{
    public interface ILineupService
    {

        Task<LineupDto> CreateAsync(LineupDto dto);
        Task<LineupDto> UpdateAsync(LineupDto dto);
        Task DeleteAsync(int festivalId, int artistId);
        Task<LineupDto> GetAsync(int festivalId, int artistId);
        Task<IList<LineupGetDto>> GetLineupsForFestivalAsync(int festivalId);


    }
}
