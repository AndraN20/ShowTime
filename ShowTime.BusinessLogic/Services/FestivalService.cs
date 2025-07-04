using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.DTOs.Festival;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services
{
    public class FestivalService : IFestivalService
    {
        private readonly IFestivalRepository _festivalRepo;
        public FestivalService(IFestivalRepository festivalRepository)
        {
            _festivalRepo = festivalRepository;
        }
        public async Task<FestivalGetDto> GetFestivalByIdAsync(int id)
        {
            try
            {
                var festival = await _festivalRepo.GetByIdAsync(id);
                if (festival == null)
                {
                    throw new KeyNotFoundException($"Festival with ID {id} not found.");
                }
                return new FestivalGetDto
                {
                    Id = festival.Id,
                    Name = festival.Name,
                    Location = festival.Location,
                    SplashArt = festival.SplashArt,
                    StartDate = festival.StartDate,
                    EndDate = festival.EndDate
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"error finding festival with id: {id}", ex);
            }

        }
        public async Task<IList<FestivalGetDto>> GetAllFestivalsAsync()
        {
            try
            {
                var festivals = await _festivalRepo.GetAllAsync();
                if (festivals == null)
                { throw new KeyNotFoundException("Festivals not found"); }
                return festivals.Select(f => new FestivalGetDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    Location = f.Location,
                    SplashArt = f.SplashArt,
                    StartDate = f.StartDate,
                    EndDate = f.EndDate
                }
                ).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception("Error finding festivals", ex);
            }
        }
        public async Task<FestivalGetDto> CreateFestivalAsync(FestivalCreateDto festivalCreateDto)
        {
            var festival = new Festival
            {
                Name = festivalCreateDto.Name,
                Location = festivalCreateDto.Location,
                StartDate = festivalCreateDto.StartDate,
                EndDate = festivalCreateDto.EndDate,
                SplashArt = festivalCreateDto.SplashArt,
            };
            var createdFestival = await _festivalRepo.CreateAsync(festival);
            return new FestivalGetDto
            {
                Name = createdFestival.Name,
                Location = createdFestival.Location,
                SplashArt = createdFestival.SplashArt,
                StartDate = createdFestival.StartDate,
                EndDate = createdFestival.EndDate,
            };
        }
        public async Task<FestivalGetDto> UpdateFestivalAsync(int id, FestivalUpdateDto festivalUpdateDto)
        {
            try
            {
                var festival = await _festivalRepo.GetByIdAsync(id);
                if (festival == null)
                {
                    throw new KeyNotFoundException($"Festival with ID {id} not found.");
                }
                festival.Name = festivalUpdateDto.Name ?? festival.Name;
                festival.Location = festivalUpdateDto.Location ?? festival.Location;
                festival.StartDate = festivalUpdateDto.StartDate ?? festival.StartDate;
                festival.EndDate = festivalUpdateDto.EndDate ?? festival.EndDate;
                festival.SplashArt = festivalUpdateDto.SplashArt ?? festival.SplashArt;
                await _festivalRepo.UpdateAsync(festival);
                return new FestivalGetDto
                {
                    Name = festival.Name,
                    Location = festival.Location,
                    StartDate = festival.StartDate,
                    EndDate = festival.EndDate,
                    SplashArt = festival.SplashArt
                };
            }
            catch (
            Exception ex)
            {
                {
                    throw new Exception($"Error updating festival with id: {id}", ex);
                }
            }
        }
        public async Task DeleteFestivalAsync(int id)
        {
            try
            {
                var festival = await _festivalRepo.GetByIdAsync(id);
                if (festival == null)
                {
                    throw new KeyNotFoundException($"Festival with ID {id} not found.");
                }
                await _festivalRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting festival with id {id}", ex);
            }
        }

        public async Task<IList<FestivalGetDto>> GetFestivalsForArtistAsync(int id)
        {
            try
            {
                var festivals = await _festivalRepo.GetAllByArtistAsync(id);
                return festivals.Select(f => new FestivalGetDto
                {
                    Name = f.Name,
                    Location = f.Location,
                    StartDate = f.StartDate,
                    EndDate = f.EndDate,
                    SplashArt = f.SplashArt
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting festivals for artist with id: {id}", ex);
            }
        }
    }
}
