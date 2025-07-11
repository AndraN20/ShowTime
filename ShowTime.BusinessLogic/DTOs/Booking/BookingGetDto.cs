namespace ShowTime.BusinessLogic.DTOs.Booking
{
    public class BookingGetDto
    {
        public int FestivalId { get; set; }
        public string FestivalName { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string UserEmail { get; set; } = string.Empty;
        public int TicketId { get; set; }
        public string TicketName { get; set; } = string.Empty;
        public int TicketPrice { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
