
using BlogWebApplication.Models.DTO;
using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Model;

namespace BlogWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorisController : ControllerBase
    {
        private readonly ICategoryBL _categoryBL;
        public CategorisController(ICategoryBL categoryBL)
        {
            _categoryBL = categoryBL;
        }

        [HttpPost("/v1/CreateCategory")]
        public  async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            Category category = new Category()
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            object data = await _categoryBL.CreateAsync(category);
            return Ok(data);
        }

        [HttpGet("/v1/GetCategorys")]
        public async Task<IActionResult> GetAllCategory()
        {
            IEnumerable<Category> categoryList = await _categoryBL.GetAllAsync();
            return Ok(categoryList);
        }

        [HttpGet("v1/GetCatgoryById")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            Category category = await _categoryBL.GetCategoryById(id);
            return Ok(category);
        }


    }
}
