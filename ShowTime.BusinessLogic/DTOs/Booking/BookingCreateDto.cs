namespace ShowTime.BusinessLogic.DTOs.Booking
{
    public class BookingCreateDto
    {
        public int FestivalId { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
