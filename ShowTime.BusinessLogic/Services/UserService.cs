using Microsoft.AspNetCore.Identity;
using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.DTOs.Auth;
using ShowTime.BusinessLogic.DTOs.User;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _passwordHasher = new PasswordHasher<User>();
        }
        public async Task<UserGetDto> CreateUserAsync(UserCreateDto dto)
        {
            try
            {
                var user = new User
                {
                    Email = dto.Email,
                    Role = Role.User
                };
                user.Password = _passwordHasher.HashPassword(user, dto.Password);

                var created = await _userRepo.CreateAsync(user);

                return new UserGetDto
                {
                    Id = created.Id,
                    Email = created.Email,
                    Role = created.Role
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating user.", ex);
            }
        }
        public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
        {
            try
            {
                var user = await _userRepo.GetByEmailAsync(loginDto.Email);
                if (user == null)
                    throw new Exception("Incorrect email or password.");

                var result = _passwordHasher.VerifyHashedPassword(user, user.Password, loginDto.Password);
                if (result == PasswordVerificationResult.Failed)
                    throw new Exception("Incorrect email or password.");

                return new LoginResponseDto
                {
                    Role = (int)user.Role,
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error during authentication.", ex);
            }
        }
        public async Task<UserGetDto> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userRepo.GetByIdAsync(id)
                    ?? throw new KeyNotFoundException($"User with ID {id} does not exist.");

                return new UserGetDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Role = user.Role
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving user with id {id}.", ex);
            }
        }

        public async Task<IList<UserGetDto>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userRepo.GetAllAsync();
                return users.Select(u => new UserGetDto
                {
                    Id = u.Id,
                    Email = u.Email,
                    Role = u.Role
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all users.", ex);
            }
        }

        public async Task<UserGetDto> UpdateUserAsync(int id, UserUpdateDto dto)
        {
            try
            {
                var user = await _userRepo.GetByIdAsync(id)
                    ?? throw new KeyNotFoundException($"User with ID {id} does not exist.");

                if (!string.IsNullOrWhiteSpace(dto.Password))
                {
                    user.Password = _passwordHasher.HashPassword(user, dto.Password);
                }

                if (dto.Role.HasValue)
                {
                    user.Role = dto.Role.Value;
                }

                var updated = await _userRepo.UpdateAsync(user);

                return new UserGetDto
                {
                    Id = updated.Id,
                    Email = updated.Email,
                    Role = updated.Role
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating user with id {id}.", ex);
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            try
            {
                var user = await _userRepo.GetByIdAsync(id)
                    ?? throw new KeyNotFoundException($"User with ID {id} does not exist.");
                await _userRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting user with id {id}.", ex);
            }
        }

        public async Task<UserGetDto> GetUserByEmailAsync(string email)
        {
            try {
                var user = await _userRepo.GetByEmailAsync(email);
                return new UserGetDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Role = user.Role
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting user with email {email}.", ex);
            }
        }
    }
}
