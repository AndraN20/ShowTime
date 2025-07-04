﻿namespace ShowTime.DataAccess.Models
{
    public class Booking
    {
        public int FestivalId { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public int Price { get; set; }
        public Festival Festival { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
