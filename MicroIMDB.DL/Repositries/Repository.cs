using MicroIMDb.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MicroIMDb.Infrastructure.Repositories
{

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MicroIMDbDbContext _context;

        public Repository(MicroIMDbDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> condition = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (condition != null)
            {
                query = query.Where(condition);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> match)
        {
            IQueryable<T> query = _context.Set<T>();

            if (match != null)
            {
                query = query.Where(match);
            }

            return await query.FirstOrDefaultAsync(match);
        }

        public async Task<T> AddAsync(T entity)
        {
            var entityEntry = await _context.Set<T>().AddAsync(entity);

            return entityEntry.Entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entityEntry = _context.Set<T>().Update(entity);
            return entityEntry.Entity;
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
