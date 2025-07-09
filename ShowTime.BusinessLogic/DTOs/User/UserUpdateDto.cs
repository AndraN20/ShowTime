using ShowTime.DataAccess.Models;

namespace ShowTime.BusinessLogic.DTOs.User
{
    public class UserUpdateDto
    {
        public string? Password { get; set; }
        public Role? Role { get; set; }
    }
}
