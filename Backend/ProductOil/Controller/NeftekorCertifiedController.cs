using Microsoft.AspNetCore.Mvc;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeftekorCertifiedController : ValuesController<Enitiy.NeftekorCertified, Repository.Enum.NeftekorCertifiedRepository>
    {
        public NeftekorCertifiedController(IGenericRepository<NeftekorCertified> repository) : base(repository)
        {
        }
    }
}
