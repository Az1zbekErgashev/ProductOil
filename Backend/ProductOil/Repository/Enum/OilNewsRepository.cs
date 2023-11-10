using ProductOil.Data;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Repository.Enum
{
    public class OilNewsRepository : GenericRepository<OilNews, AppDbContext>
    {
        public OilNewsRepository(AppDbContext context) : base(context) { }
    }
}
