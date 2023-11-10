using Microsoft.EntityFrameworkCore;
using ProductOil.Enitiy;
using System.Linq.Expressions;

namespace ProductOil.Servis
{
    public class GenericRepository<TRes, TContext> : IGenericRepository<TRes> where TRes : class, IGeneric where TContext : DbContext
    {
        private readonly TContext _context;
        public GenericRepository(TContext context)
        {
            _context = context;
        }
        public async Task<TRes> Create(TRes res)
        {
            _context.Set<TRes>().Add(res);
            await _context.SaveChangesAsync();
            return res;
        }

        public async Task<TRes> Delete(int id)
        {
            var entity = await _context.Set<TRes>().FindAsync(id);
            if (entity == null) return entity;

            _context.Set<TRes>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TRes?> Get(int id) => await _context.Set<TRes>().FindAsync(id);

        public async Task<List<TRes>> GetAll() => await _context.Set<TRes>().ToListAsync();

        public async Task<IEnumerable<TRes>> GetAllAsync() => await _context.Set<TRes>().ToListAsync();

        public async Task<IEnumerable<TRes>> GetAllIncludesAsync(params Expression<Func<TRes, object>>[] include)
        {
            var query = _context.Set<TRes>().AsQueryable();
            query = include.Aggregate(query, (current, includes) => current.Include(includes));
            return await query.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TRes> Update(TRes res)
        {
            _context.Entry(res).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return res;
        }
    }
}
