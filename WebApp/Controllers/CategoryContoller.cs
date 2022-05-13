using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Model;

namespace WebApp.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoryContoller : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryContoller(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet("/all")]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return await categoryRepository.GetCategoriesAsync();
        }

        [HttpPost("/add")]
        public async Task<ActionResult> AddCategory(Category category)
        {
            bool createSuccesful = await categoryRepository.AddCategoryAsync(category);
            if(createSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
