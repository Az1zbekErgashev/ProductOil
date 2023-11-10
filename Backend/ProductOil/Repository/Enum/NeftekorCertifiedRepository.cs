using ProductOil.Data;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Repository.Enum
{
    public class NeftekorCertifiedRepository : GenericRepository<NeftekorCertified, AppDbContext>
    {
        public NeftekorCertifiedRepository(AppDbContext context) : base(context) { }
    }
}
