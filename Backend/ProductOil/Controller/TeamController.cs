using Microsoft.AspNetCore.Mvc;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Controller;

[Route("api/[controller]")]
[ApiController]
public class TeamController : ValuesController<Team, Repository.Enum.TeamRepository>
{
    public TeamController(IGenericRepository<Team> repository) : base(repository)
    {

    }
}
