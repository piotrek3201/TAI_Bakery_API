using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Model;

namespace WebApp.Controllers
{
    [Route("/api/categories")]
    [Tags("Categories")]
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
            return await categoryRepository.GetAllCategoriesAsync();
        }

        [HttpGet("/{id}")]
        public async Task<Category> GetCategoryById(long id)
        {
            return await categoryRepository.GetCategoryByIdAsync(id);
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

        [HttpPut("/update")]
        public async Task<ActionResult> UpdateCategory(Category category)
        {
            bool updateSuccesful = await categoryRepository.UpdateCategoryAsync(category);
            if(updateSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("/delete/{id}")]
        public async Task<ActionResult> DeleteCategory(long id)
        {
            bool deleteSuccesful = await categoryRepository.DeleteCategoryAsync(id);
            if(deleteSuccesful)
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
