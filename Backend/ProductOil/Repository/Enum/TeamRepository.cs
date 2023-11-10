using ProductOil.Data;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Repository.Enum;
public class TeamRepository : GenericRepository<Team, AppDbContext>
{
    public TeamRepository(AppDbContext context) : base(context) { }
}
