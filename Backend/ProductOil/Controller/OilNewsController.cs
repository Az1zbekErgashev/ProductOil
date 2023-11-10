using Microsoft.AspNetCore.Mvc;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OilNewsController : ValuesController<Enitiy.OilNews, Repository.Enum.OilNewsRepository>
    {
        public OilNewsController(IGenericRepository<OilNews> repository) : base(repository)
        {
        }
    }
}
