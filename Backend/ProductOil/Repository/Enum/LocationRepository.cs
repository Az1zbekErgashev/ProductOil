using ProductOil.Data;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Repository.Enum
{
    public class LocationRepository : GenericRepository<Location, AppDbContext>
    {
        public LocationRepository(AppDbContext context) : base(context) { }
    }
}
