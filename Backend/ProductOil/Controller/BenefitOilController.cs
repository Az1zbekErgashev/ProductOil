using Microsoft.AspNetCore.Mvc;
using ProductOil.Enitiy;
using ProductOil.Servis;
namespace ProductOil.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitOilController : ValuesController<Enitiy.BenefitOil, Repository.Enum.BenefitOilRepository>
    {
        public BenefitOilController(IGenericRepository<BenefitOil> repository) : base(repository)
        {
        }
    }
}
