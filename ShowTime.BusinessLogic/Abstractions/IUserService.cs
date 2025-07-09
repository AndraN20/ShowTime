using ShowTime.BusinessLogic.DTOs.Auth;
using ShowTime.BusinessLogic.DTOs.User;

namespace ShowTime.BusinessLogic.Abstractions
{
    public interface IUserService
    {
        Task<UserGetDto> CreateUserAsync(UserCreateDto dto);
        Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
        Task<UserGetDto> GetUserByIdAsync(int id);
        Task<IList<UserGetDto>> GetAllUsersAsync();
        Task<UserGetDto> UpdateUserAsync(int id, UserUpdateDto dto);
        Task DeleteUserAsync(int id);
        Task<UserGetDto> GetUserByEmailAsync(string email);
    }
}
