using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.DTOs;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IRepository<Artist> _artistRepo;

        public ArtistService(IRepository<Artist> artistRepo)
        {
            _artistRepo = artistRepo;
        }

        public async Task<ArtistGetDto> CreateArtistAsync(ArtistCreateDto artistCreateDto)
        {
            try
            {
                var artist = new Artist
                {
                    Name = artistCreateDto.Name,
                    Genre = artistCreateDto.Genre,
                    Image = artistCreateDto.Image
                };
                var createdArtist = await _artistRepo.CreateAsync(artist);
                return new ArtistGetDto
                {
                    Id = createdArtist.Id,
                    Name = createdArtist.Name,
                    Genre = createdArtist.Genre,
                    Image = createdArtist.Image
                };

            }
            catch (Exception ex)
            {
                throw new Exception("Error adding user.", ex);

            }
        }

        public async Task DeleteArtistAsync(int id)
        {
            try
            {
                var artist = await _artistRepo.GetByIdAsync(id);
                if (artist == null)
                {
                    throw new KeyNotFoundException($"Artist with ID {id} not found.");
                }
                await _artistRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting artist with id {id}", ex);
            }
        }

        public async Task<IEnumerable<ArtistGetDto>> GetAllArtistsAsync()
        {
            try
            {
                var artists = await _artistRepo.GetAllAsync();
                var artistDtos = artists.Select(artist => new ArtistGetDto
                {
                    Id = artist.Id,
                    Name = artist.Name,
                    Genre = artist.Genre,
                    Image = artist.Image

                });
                return artistDtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving artists", ex);
            }
        }

        public async Task<ArtistGetDto> GetArtistByIdAsync(int id)
        {
            try
            {
                var artist = await _artistRepo.GetByIdAsync(id);
                if (artist == null)
                {
                    throw new KeyNotFoundException($"Artist with ID {id} not found.");
                }
                return new ArtistGetDto
                {
                    Id = artist.Id,
                    Name = artist.Name,
                    Genre = artist.Genre,
                    Image = artist.Image
                };
            }
            catch (Exception ex)
            {

                throw new Exception($"Error trying to find artist with ID {id}", ex);
            }
        }

        public async Task<ArtistGetDto> UpdateArtistAsync(int id, ArtistUpdateDto artistDto)
        {
            try
            {
                var artist = await _artistRepo.GetByIdAsync(id);
                if (artist == null)
                {
                    throw new KeyNotFoundException($"Artist with ID {id} not found.");
                }
                artist.Name = artistDto.Name;
                artist.Genre = artistDto.Genre;
                artist.Image = artistDto.Image;
                await _artistRepo.UpdateAsync(artist);
                return new ArtistGetDto
                {
                    Name = artist.Name,
                    Genre = artistDto.Genre,
                    Image = artistDto.Image
                };
            }
            catch (
            Exception ex)
            {
                {
                    throw new Exception($"Error updating artist with id: {id}", ex);
                }
            }
        }
    }
}
