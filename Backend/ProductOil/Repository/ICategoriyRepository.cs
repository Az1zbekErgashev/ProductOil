using ProductOil.Dto;
using ProductOil.Enitiy;

namespace ProductOil.Repository
{
    public interface ICategoriyRepository
    {
        Task<List<Enitiy.Categoriy>> GetAllAsync();
        Task<Categoriy> GetByIdAsync(int id);
        Task<Categoriy> CreateAsync(Dto.CategoriyDto categoriyDto);
        Task<Categoriy> UpdateAsync(int id, CategoriyDto categoriyDto);
        Task DeleteAsync(int id);
    }
}
