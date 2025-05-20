using CQRSSample_0.Models.ContextClasses;
using CQRSSample_0.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace CQRSSample_0.Repositories.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        readonly MyContext _context;
        public BaseRepository(MyContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
