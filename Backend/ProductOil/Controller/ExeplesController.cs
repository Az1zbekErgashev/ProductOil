using Microsoft.AspNetCore.Mvc;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExeplesController : ValuesController<Enitiy.Exemples, Repository.Enum.ExemplesRepository>
    {
        public ExeplesController(IGenericRepository<Exemples> repository) : base(repository)
        {
        }
    }
}
