using Microsoft.AspNetCore.Mvc;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ValuesController<Enitiy.FeedBack, Repository.Enum.FeedBackRepository>
    {
        public FeedBackController(IGenericRepository<FeedBack> repository) : base(repository)
        {
        }
    }
}
