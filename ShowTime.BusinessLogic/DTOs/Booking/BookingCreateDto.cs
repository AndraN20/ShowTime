namespace ShowTime.BusinessLogic.DTOs.Booking
{
    public class BookingCreateDto
    {
        public int FestivalId { get; set; }
        public int UserId { get; set; }
        public int TicketId { get; set; }
        public int Quantity { get; set; }
    }
}
