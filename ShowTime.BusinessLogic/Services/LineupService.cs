using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.DTOs.Lineup;
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

        public async Task<LineupDto> CreateAsync(LineupDto dto)
        {
            try
            {
                var existing = await _lineupRepo.GetAsync(dto.FestivalId, dto.ArtistId);
                if (existing != null)
                    throw new Exception("This artist is already scheduled for this festival!");


                var entity = new Lineup
                {
                    FestivalId = dto.FestivalId,
                    ArtistId = dto.ArtistId,
                    Stage = dto.Stage,
                    StartTime = dto.StartTime
                };

                var created = await _lineupRepo.CreateAsync(entity);

                return new LineupDto
                {
                    FestivalId = created.FestivalId,
                    ArtistId = created.ArtistId,
                    Stage = created.Stage,
                    StartTime = created.StartTime
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating lineup.", ex);
            }
        }

        public async Task DeleteAsync(int festivalId, int artistId)
        {
            try
            {
                await _lineupRepo.DeleteAsync(festivalId, artistId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting lineup for festival {festivalId} and artist {artistId}.", ex);
            }
        }

        public async Task<LineupDto> GetAsync(int festivalId, int artistId)
        {
            try
            {
                var lineup = await _lineupRepo.GetAsync(festivalId, artistId);
                if (lineup == null)
                    throw new KeyNotFoundException($"Lineup not found for festival {festivalId} and artist {artistId}.");
                return new LineupDto
                {
                    FestivalId = lineup.FestivalId,
                    ArtistId = lineup.ArtistId,
                    Stage = lineup.Stage,
                    StartTime = lineup.StartTime
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving lineup for festival {festivalId} and artist {artistId}.", ex);
            }
        }



        public async Task<LineupDto> UpdateAsync(LineupDto dto)
        {
            var entity = await _lineupRepo.GetAsync(dto.FestivalId, dto.ArtistId);
            if (entity == null)
                throw new Exception("Lineup not found.");

            entity.Stage = dto.Stage;
            entity.StartTime = dto.StartTime;

            var updated = await _lineupRepo.UpdateAsync(entity);

            return new LineupDto
            {
                FestivalId = updated.FestivalId,
                ArtistId = updated.ArtistId,
                Stage = updated.Stage,
                StartTime = updated.StartTime
            };
        }

        public async Task<IList<LineupGetDto>> GetLineupsForFestivalAsync(int festivalId)
        {
            try
            {
                var lineups = await _lineupRepo.GetLineupsForFestivalAsync(festivalId);
                return lineups.Select(
                    l => new LineupGetDto
                    {
                        FestivalId = l.FestivalId,
                        ArtistId = l.ArtistId,
                        Stage = l.Stage,
                        StartTime = l.StartTime,
                        ArtistName = l.Artist.Name,
                        ArtistImage = l.Artist.Image

                    }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving lineups for festival with ID {festivalId}.", ex);
            }
        }
    }
}

