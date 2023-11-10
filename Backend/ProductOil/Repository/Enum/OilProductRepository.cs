using ProductOil.Data;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Repository.Enum
{
    public class OilProductRepository : GenericRepository<OilProduct, AppDbContext>
    {
        public OilProductRepository(AppDbContext context) : base(context) { }
    }
}
