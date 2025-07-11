namespace ShowTime.DataAccess.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int FestivalId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public int MaxQuantity { get; set; }
        public virtual Festival Festival { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
