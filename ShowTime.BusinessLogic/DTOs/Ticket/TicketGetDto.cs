namespace ShowTime.BusinessLogic.DTOs.Ticket
{
    public class TicketGetDto
    {
        public int Id { get; set; }
        public int FestivalId { get; set; }
        public string Name { get; set; } = "";
        public int Price { get; set; }
        public int MaxQuantity { get; set; }
    }
}
