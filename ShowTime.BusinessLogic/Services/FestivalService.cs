using ShowTime.BusinessLogic.Abstractions;
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
        public async Task<Festival?> GetFestivalByIdAsync(int id)
        {
            return await _festivalRepo.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Festival>> GetAllFestivalsAsync()
        {
            return await _festivalRepo.GetAllAsync();
        }
        public async Task<Festival> CreateFestivalAsync(Festival festival)
        {
            return await _festivalRepo.CreateAsync(festival);
        }
        public async Task<Festival> UpdateFestivalAsync(Festival festival)
        {
            return await _festivalRepo.UpdateAsync(festival);
        }
        public async Task DeleteFestivalAsync(int id)
        {
            await _festivalRepo.DeleteAsync(id);
        }
    }
}
