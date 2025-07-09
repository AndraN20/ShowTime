namespace ShowTime.DataAccess.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();
    }
}
