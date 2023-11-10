using ProductOil.Data;
using ProductOil.Enitiy;
using ProductOil.Servis;
namespace ProductOil.Repository.Enum
{
    public class ClientRepository : GenericRepository<Client, AppDbContext>
    {
        public ClientRepository(AppDbContext context) : base(context) { }
    }
}
