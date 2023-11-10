using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ValuesController<Enitiy.Contact, Repository.Enum.ContactRepository>
    {
        public ContactController(IGenericRepository<Contact> repository) : base(repository)
        {
        }
    }
}
