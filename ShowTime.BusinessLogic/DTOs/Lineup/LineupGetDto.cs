namespace ShowTime.BusinessLogic.DTOs.Lineup
{
    public class LineupGetDto
    {
        public int FestivalId { get; set; }
        public int ArtistId { get; set; }
        public string Stage { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public string ArtistName { get; set; } = string.Empty;
        public string ArtistImage { get; set; } = string.Empty;
    }
}
