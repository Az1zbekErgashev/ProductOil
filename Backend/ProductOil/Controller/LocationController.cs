using Microsoft.AspNetCore.Mvc;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ValuesController<Enitiy.Location, Repository.Enum.LocationRepository>
    {
        public LocationController(IGenericRepository<Location> repository) : base(repository)
        {
        }
    }
}
