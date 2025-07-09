using ShowTime.BusinessLogic.DTOs.Genre;

namespace ShowTime.BusinessLogic.DTOs.Artist
{
    public class ArtistUpdateDto
    {
        public string? Name { get; set; } = string.Empty;
        public string? Image { get; set; } = string.Empty;
        public IList<int>? GenreIds { get; set; }
    }
}
