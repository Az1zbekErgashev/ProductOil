using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductOil.Dto;
using ProductOil.Repository;

namespace ProductOil.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CatgoriyController : ControllerBase
    {
        private readonly ICategoriyRepository _categoriy;

        public CatgoriyController(ICategoriyRepository categoriy)
        {
            this._categoriy = categoriy;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _categoriy.GetAllAsync());
        [HttpGet("Id")]
        public async Task<IActionResult> GetById(int id) => Ok(await _categoriy.GetByIdAsync(id));
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CategoriyDto categoriy) => Ok(await _categoriy.CreateAsync(categoriy));
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, CategoriyDto categoriy) => Ok(await _categoriy.UpdateAsync(id, categoriy));
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _categoriy.DeleteAsync(id);
            return Ok();
        }
    }
}
