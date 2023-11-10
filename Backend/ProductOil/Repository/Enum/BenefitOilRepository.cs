using ProductOil.Data;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Repository.Enum
{
    public class BenefitOilRepository : GenericRepository<BenefitOil, AppDbContext>
    {
        public BenefitOilRepository(AppDbContext context) : base(context) { }
    }
}
