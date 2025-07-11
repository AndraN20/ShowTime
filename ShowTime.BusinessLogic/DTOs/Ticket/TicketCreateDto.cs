namespace ShowTime.BusinessLogic.DTOs.Ticket
{
    public class TicketCreateDto
    {
        public int FestivalId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public int MaxQuantity { get; set; }
    }
}
