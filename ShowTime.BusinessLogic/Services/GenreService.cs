using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.DTOs.Genre;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepo;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepo = genreRepository;
        }
        public async Task<GenreGetDto> CreateGenreAsync(string genreName)
        {
            try
            {
                var genre = new Genre
                {
                    Name = genreName,
                };
                var createdGenre = await _genreRepo.CreateAsync(genre);
                return new GenreGetDto
                {
                    Id = createdGenre.Id,
                    Name = createdGenre.Name,
                };

            }
            catch (Exception ex)
            {
                throw new Exception("Error adding genre.", ex);

            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var genre = await _genreRepo.GetByIdAsync(id);
                if (genre == null)
                {
                    throw new KeyNotFoundException($"Genre with ID {id} not found.");
                }
                await _genreRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting genre with id {id}", ex);
            }
        }

        public async Task<IList<GenreGetDto>> GetAllGenresAsync()
        {
            try
            {
                var genres = await _genreRepo.GetAllAsync();
                var genresDtos = genres.Select(genre => new GenreGetDto
                {
                    Id = genre.Id,
                    Name = genre.Name,


                });
                return genresDtos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving genres", ex);
            }
        }

        public async Task<GenreGetDto> GetGenreByIdAsync(int id)
        {
            try
            {
                var genre = await _genreRepo.GetByIdAsync(id);
                if (genre == null)
                {
                    throw new KeyNotFoundException($"Genre with ID {id} not found.");
                }
                return new GenreGetDto
                {
                    Id = genre.Id,
                    Name = genre.Name
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error trying to find genre with ID {id}", ex);
            }
        }

        public async Task<IList<GenreGetDto>> GetGenresByIdsAsync(IList<int> ids)
        {
            try
            {
                var genres = await _genreRepo.GetByIdsAsync(ids);
                return genres.Select(genre => new GenreGetDto
                {
                    Id = genre.Id,
                    Name = genre.Name
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving genres by IDs", ex);
            }
        }
    }
}
