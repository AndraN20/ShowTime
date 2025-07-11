using ShowTime.BusinessLogic.DTOs.Ticket;

namespace ShowTime.BusinessLogic.Abstractions
{
    public interface ITicketService
    {
        Task<IList<TicketGetDto>> GetTicketsForFestivalAsync(int festivalId);
        Task<TicketGetDto?> GetByIdAsync(int id);
        Task<IList<TicketGetDto>> GetAllAsync();
        Task<TicketGetDto> CreateAsync(TicketCreateDto dto);
        Task<TicketGetDto> UpdateAsync(int id, TicketUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
