using ProductOil.Enitiy;
using System.Linq.Expressions;

namespace ProductOil.Servis
{
    public interface IGenericRepository<Res> where Res : class, IGeneric
    {
        Task<IEnumerable<Res>> GetAllAsync();
        Task<IEnumerable<Res>> GetAllIncludesAsync(params Expression<Func<Res, object>>[] include);
        Task<List<Res>> GetAll();
        Task<Res?> Get(int id);
        Task<Res> Create(Res res);
        Task<Res> Update(Res res);
        Task<Res> Delete(int id);
        Task SaveAsync();

    }
}
