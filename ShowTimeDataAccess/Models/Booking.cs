using System.Net.Sockets;

namespace ShowTime.DataAccess.Models
{
    public class Booking
    {
        public int FestivalId { get; set; }
        public int UserId { get; set; }
        public int TicketId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public virtual Festival Festival { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual Ticket Ticket { get; set; } = null!;
    }
}
