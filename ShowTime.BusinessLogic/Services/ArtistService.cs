using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.DTOs.Artist;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepo;

        public ArtistService(IArtistRepository artistRepo)
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

        public async Task<IList<ArtistGetDto>> GetAllArtistsAsync()
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
                return artistDtos.ToList();
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

        public async Task<IList<ArtistGetDto>> GetArtistsForFestivalAsync(int id)
        {
            try {
                var artists = await _artistRepo.GetAllByFestivalAsync(id);
                if (artists == null)
                {
                    throw new KeyNotFoundException($"Artists for festival with id {id} not found");
                }
                return artists.Select(artist => new ArtistGetDto
                {
                    Id = artist.Id,
                    Name = artist.Name,
                    Genre = artist.Genre,
                    Image = artist.Image
                }).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception($"Error finding artists for festival with id: {id}", ex);
            }
        }

        public async Task<ArtistGetDto> UpdateArtistAsync(int id, ArtistUpdateDto artistUpdateDto)
        {
            try
            {
                var artist = await _artistRepo.GetByIdAsync(id);
                if (artist == null)
                {
                    throw new KeyNotFoundException($"Artist with ID {id} not found.");
                }
                artist.Name = artistUpdateDto.Name ?? artist.Name;
                artist.Genre = artistUpdateDto.Genre ?? artist.Genre;
                artist.Image = artistUpdateDto.Image ?? artist.Image;
                await _artistRepo.UpdateAsync(artist);
                return new ArtistGetDto
                {
                    Name = artist.Name,
                    Genre = artist.Genre,
                    Image = artist.Image
                };
            }
            catch (Exception ex)
            {
                {
                    throw new Exception($"Error updating artist with id: {id}", ex);
                }
            }
        }

    }
}
