using AleyantPrint.Domain.Models;
using AleyantPrint.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AleyantPrint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Category>> GetCategoryAsync(string name)
        {
            var category = await _service.GetCategoryAsync(name);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategoryAsync()
        {
            var categories = await _service.GetAllCategoryAsync();
            if (categories.Count == 0)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult> AddCategoryAsync([FromBody] Dictionary<string, string> categories)
        {
            try
            {
                foreach (var pair in categories)
                {
                    var category = new Category
                    {
                        Name = pair.Value,
                        ParentName = pair.Key
                    };
                    await _service.AddCategoryAsync(category);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategoryAsync(Category category)
        {
            try
            {
                await _service.UpdateCategoryAsync(category);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult> DeleteCategoryAsync(string name)
        {
            await _service.DeleteCategoryAsync(name);
            return NoContent();
        }
    }
}
