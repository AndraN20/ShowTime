using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.DTOs.Auth;

namespace ShowTime.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
        {
            return new LoginResponseDto()
            {
                Role = 1
            };
        }
    }
}
