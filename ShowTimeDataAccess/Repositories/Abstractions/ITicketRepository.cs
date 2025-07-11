using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Repositories.Abstractions
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> GetTicketsForFestivalAsync(int festivalId);
        Task<Ticket?> GetByNameAsync(int festivalId, string name);
    }
}
