using ProductOil.Data;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Repository.Enum
{
    public class OilCompanyRepository : GenericRepository<OilCompany, AppDbContext>
    {
        public OilCompanyRepository(AppDbContext context) : base(context) { }
    }
}
