using ProductOil.Data;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Repository.Enum
{
    public class ExemplesRepository : GenericRepository<Exemples, AppDbContext>
    {
        public ExemplesRepository(AppDbContext context) : base(context) { }
    }
}
