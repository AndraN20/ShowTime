namespace ShowTime.BusinessLogic.DTOs.Booking
{
    public class BookingGetDto
    {
        public int FestivalId { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
