using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Model;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    [Tags("Categories")]
    public class CategoryContoller : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryContoller(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        //GET: api/categories/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return await categoryRepository.GetAllCategoriesAsync();
        }

        //GET: api/categories/{id}
        [HttpGet("{id}")]
        public async Task<Category> GetCategoryById(long id)
        {
            return await categoryRepository.GetCategoryByIdAsync(id);
        }

        //POST: api/categories/add
        [HttpPost("add")]
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

        //PUT: api/categories/update
        [HttpPut("update")]
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

        //DELETE: api/categories/delete/{id}
        [HttpDelete("delete/{id}")]
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
