using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.DataAccess.Repositories.Implementations
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly ShowTimeDbContext _context;

        public BaseRepository(ShowTimeDbContext context)
        {
            _context = context;
        }
       

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding entity: {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = _context.Set<TEntity>().Find(id);
                if(entity == null)
                {
                    throw new KeyNotFoundException($"Entity with ID {id} not found.");
                }
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting entity with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
               return await _context.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting entities: {ex.Message}",ex);
            }
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<TEntity>().FindAsync(id);  
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting entity: {ex.Message}", ex);
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try {

                _context.Set<TEntity>().Update(entity);   
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex) {
                throw new Exception($"Error updating entity: {ex.Message}",ex);
            }
        }
    }
}
