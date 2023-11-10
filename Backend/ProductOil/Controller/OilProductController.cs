using Microsoft.AspNetCore.Mvc;
using ProductOil.Servis;

namespace ProductOil.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OilProductController : ValuesController<Enitiy.OilProduct, Repository.Enum.OilProductRepository>
    {
        public OilProductController(IGenericRepository<Enitiy.OilProduct> repository) : base(repository)
        {
        }
    }
}
