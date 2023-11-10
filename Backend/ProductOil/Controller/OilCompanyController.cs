using Microsoft.AspNetCore.Mvc;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OilCompanyController : ValuesController<Enitiy.OilCompany, Repository.Enum.OilCompanyRepository>
    {
        public OilCompanyController(IGenericRepository<OilCompany> repository) : base(repository)
        {
        }
    }
}
