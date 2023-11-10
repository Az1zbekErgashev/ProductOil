using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductOil.Enitiy;
using ProductOil.Servis;

namespace ProductOil.Controller;

[Route("api/[controller]")]
[ApiController]
public abstract class ValuesController<TRes, TRepository> : ControllerBase where TRes : class, IGeneric where TRepository : IGenericRepository<TRes>
{
    private readonly IGenericRepository<TRes> _repository;
    protected ValuesController(IGenericRepository<TRes> repository) => _repository = repository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TRes>>> Get() => await _repository.GetAll();

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TRes>> Get(int id)
    {
        var movie = await _repository.Get(id);
        if (movie == null) return NotFound();
        return movie;
    }
    [HttpPut("{id}")]
    [Authorize(Roles = "ADMIN, OWNER")]
    public virtual async Task<ActionResult> Put(int id, TRes tres)
    {
        if (id != tres.Id)
            return BadRequest();
        await _repository.Update(tres);
        return NoContent();
    }
    [HttpPost]
    [Authorize(Roles = "ADMIN,OWNER")]

    public virtual async Task<ActionResult<TRes>> Post(TRes tres)
    {
        await _repository.Create(tres);
        return tres;
    }
    [HttpDelete("{id}")]
    [Authorize(Roles = "ADMIN,OWNER")]
    public virtual async Task<ActionResult<TRes>> Delete(int id)
    {
        var movie = await _repository.Delete(id);
        return movie;
    }

    [HttpGet("async")]
    public virtual async Task<ActionResult<IEnumerable<TRes>>> GetAllAsync()
    {
        var ehtities = await _repository.GetAll();
        return Ok(ehtities);
    }

}
