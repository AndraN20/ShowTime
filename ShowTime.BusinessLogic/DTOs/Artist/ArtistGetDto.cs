using ShowTime.BusinessLogic.DTOs.Genre;

namespace ShowTime.BusinessLogic.DTOs.Artist
{
    public class ArtistGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public IList<GenreGetDto> Genres { get; set; } = new List<GenreGetDto>();
    }
}
