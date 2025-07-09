using Microsoft.EntityFrameworkCore;
using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.DTOs.Artist;
using ShowTime.BusinessLogic.DTOs.Genre;
using ShowTime.DataAccess;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepo;
        private readonly IGenreRepository _genreRepo;

        public ArtistService(IArtistRepository artistRepo, IGenreRepository genreRepo)
        {
            _artistRepo = artistRepo;
            _genreRepo = genreRepo;

        }

        public async Task<ArtistGetDto> CreateArtistAsync(ArtistCreateDto artistCreateDto)
        {
            try
            {
                var artist = new Artist
                {
                    Name = artistCreateDto.Name,
                    Image = artistCreateDto.Image
                };
                var genres = await _genreRepo.GetByIdsAsync(artistCreateDto.GenreIds);
                if (genres == null || !genres.Any())
                {
                    throw new KeyNotFoundException("No genres found for the provided IDs.");
                }

                foreach (var g in genres)
                    artist.Genres.Add(g);

                var createdArtist = await _artistRepo.CreateAsync(artist);
                return new ArtistGetDto
                {
                    Id = createdArtist.Id,
                    Name = createdArtist.Name,
                    Image = createdArtist.Image,
                    Genres = createdArtist.Genres
                       .Select(g => new GenreGetDto { Id = g.Id, Name = g.Name })
                       .ToList()
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
                    Image = artist.Image,
                    Genres = artist.Genres
                   .Select(g => new GenreGetDto { Id = g.Id, Name = g.Name })
                   .ToList()

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
                    Image = artist.Image,
                    Genres = artist.Genres
                   .Select(g => new GenreGetDto { Id = g.Id, Name = g.Name })
                   .ToList()
                };
            }
            catch (Exception ex)
            {

                throw new Exception($"Error trying to find artist with ID {id}", ex);
            }
        }

        public async Task<IList<ArtistGetDto>> GetArtistsForFestivalAsync(int id)
        {
            try
            {
                var artists = await _artistRepo.GetAllByFestivalAsync(id);
                if (artists == null)
                {
                    throw new KeyNotFoundException($"Artists for festival with id {id} not found");
                }
                return artists.Select(artist => new ArtistGetDto
                {
                    Id = artist.Id,
                    Name = artist.Name,
                    Image = artist.Image,
                    Genres = artist.Genres
                   .Select(g => new GenreGetDto { Id = g.Id, Name = g.Name })
                   .ToList()
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error finding artists for festival with id: {id}", ex);
            }
        }

        public async Task<ArtistGetDto> UpdateArtistAsync(int id, ArtistUpdateDto artistUpdateDto)
        {
            try
            {
                var artist = await _artistRepo.GetByIdAsync(id)
          ?? throw new KeyNotFoundException($"Artist with ID {id} not found.");

                artist.Name = artistUpdateDto.Name ?? artist.Name;
                artist.Image = artistUpdateDto.Image ?? artist.Image;



                IList<Genre> existingGenres = new List<Genre>();
                if (artistUpdateDto.GenreIds?.Any() == true)
                {
                    existingGenres = await _genreRepo.GetByIdsAsync(artistUpdateDto.GenreIds);
                }
                artist.Genres.Clear();
                foreach (var g in existingGenres)
                    artist.Genres.Add(g);

                var updated = await _artistRepo.UpdateAsync(artist);

                return new ArtistGetDto
                {
                    Id = updated.Id,
                    Name = updated.Name,
                    Image = updated.Image,
                    Genres = updated.Genres
                        .Select(g => new GenreGetDto { Id = g.Id, Name = g.Name })
                        .ToList()
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating artist with id: {id}", ex);
            }
        }

    }
}
