using ProductOil.Data;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Repository.Enum
{
    public class FeedBackRepository : GenericRepository<FeedBack, AppDbContext>

    {
        public FeedBackRepository(AppDbContext context) : base(context) { }
    }
}
