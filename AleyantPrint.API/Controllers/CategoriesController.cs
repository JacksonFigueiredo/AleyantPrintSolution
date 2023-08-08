using AleyantPrint.Domain.Models;
using AleyantPrint.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AleyantPrint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _service;

        public CategoriesController(CategoryService service)
        {
            _service = service;
        }

        [HttpGet("{name}")]
        public ActionResult<Category> GetCategory(string name)
        {
            var category = _service.GetCategory(name);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public ActionResult AddCategory([FromBody] Dictionary<string, string> categories)
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
                    _service.AddCategory(category);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult UpdateCategory(Category category)
        {
            try
            {
                _service.UpdateCategory(category);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{name}")]
        public ActionResult DeleteCategory(string name)
        {
            _service.DeleteCategory(name);
            return NoContent();
        }
    }
}
