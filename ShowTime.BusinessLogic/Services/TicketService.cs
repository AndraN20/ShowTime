using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.DTOs.Ticket;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepo;

        public TicketService(ITicketRepository ticketRepo)
        {
            _ticketRepo = ticketRepo;
        }

        public async Task<IList<TicketGetDto>> GetTicketsForFestivalAsync(int festivalId)
        {
            var tickets = await _ticketRepo.GetTicketsForFestivalAsync(festivalId);
            return tickets.Select(t => new TicketGetDto
            {
                Id = t.Id,
                FestivalId = t.FestivalId,
                Name = t.Name,
                Price = t.Price,
                MaxQuantity = t.MaxQuantity
            }).ToList();
        }

        public async Task<IList<TicketGetDto>> GetAllAsync()
        {
            var tickets = await _ticketRepo.GetAllAsync();
            return tickets.Select(t => new TicketGetDto
            {
                Id = t.Id,
                FestivalId = t.FestivalId,
                Name = t.Name,
                Price = t.Price,
                MaxQuantity = t.MaxQuantity
            }).ToList();
        }

        public async Task<TicketGetDto?> GetByIdAsync(int id)
        {
            var ticket = await _ticketRepo.GetByIdAsync(id);
            if (ticket == null) return null;
            return new TicketGetDto
            {
                Id = ticket.Id,
                FestivalId = ticket.FestivalId,
                Name = ticket.Name,
                Price = ticket.Price,
                MaxQuantity = ticket.MaxQuantity
            };
        }

        public async Task<TicketGetDto> CreateAsync(TicketCreateDto dto)
        {
            var ticket = new Ticket
            {
                FestivalId = dto.FestivalId,
                Name = dto.Name,
                Price = dto.Price,
                MaxQuantity = dto.MaxQuantity
            };
            var created = await _ticketRepo.CreateAsync(ticket);
            return new TicketGetDto
            {
                Id = created.Id,
                FestivalId = created.FestivalId,
                Name = created.Name,
                Price = created.Price,
                MaxQuantity = created.MaxQuantity
            };
        }

        public async Task<TicketGetDto> UpdateAsync(int id, TicketUpdateDto dto)
        {
            var ticket = await _ticketRepo.GetByIdAsync(id);
            if (ticket == null) throw new Exception("Ticket not found.");

            ticket.Name = dto.Name ?? ticket.Name;
            ticket.Price = dto.Price ?? ticket.Price;
            ticket.MaxQuantity = dto.MaxQuantity ?? ticket.MaxQuantity;

            var updated = await _ticketRepo.UpdateAsync(ticket);
            return new TicketGetDto
            {
                Id = updated.Id,
                FestivalId = updated.FestivalId,
                Name = updated.Name,
                Price = updated.Price,
                MaxQuantity = updated.MaxQuantity
            };
        }

        public async Task DeleteAsync(int id)
        {
            await _ticketRepo.DeleteAsync(id);
        }
    }
}
