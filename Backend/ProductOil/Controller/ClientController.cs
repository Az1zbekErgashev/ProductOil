using Microsoft.AspNetCore.Mvc;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ValuesController<Enitiy.Client, Repository.Enum.ClientRepository>
    {
        public ClientController(IGenericRepository<Client> repository) : base(repository)
        {
        }
    }
}
