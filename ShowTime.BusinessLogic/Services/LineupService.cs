using ShowTime.BusinessLogic.Abstractions;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services
{
    public class LineupService : ILineupService
    {
        private readonly ILineupRepository _lineupRepo;

        public LineupService(ILineupRepository lineupRepository)
        {
            _lineupRepo = lineupRepository;
        }

        public async Task<IEnumerable<Lineup>> GetLineupsForFestivalAsync(int artistId)
        {
            return await _lineupRepo.GetLineupsForFestivalAsync(artistId);
        }
        public async Task<IEnumerable<Lineup>> GetLineupsForArtistAsync(int festivalId)
        {
            return await _lineupRepo.GetLineupsForArtistAsync(festivalId);
        }

    }
}
