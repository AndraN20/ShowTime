using ShowTime.DataAccess.Models;

namespace ShowTime.BusinessLogic.DTOs.User
{
    public class UserGetDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public Role Role { get; set; }
    }
}
