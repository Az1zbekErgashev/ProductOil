using ProductOil.Data;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Repository.Enum
{
    public class ContactRepository : GenericRepository<Contact, AppDbContext>
    {
        public ContactRepository(AppDbContext context) : base(context) { }
    }
}
