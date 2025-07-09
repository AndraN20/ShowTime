namespace ShowTime.BusinessLogic.DTOs.Lineup
{
    public class LineupDto
    {
        public int FestivalId { get; set; }
        public int ArtistId { get; set; }
        public string Stage { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
    }
}
