using Book.Api.Entities;
using Book.Api.IRepositories;
using Book.Models.Dtos;
using Book.Models.Enums;
using Book.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICatagoryRepos _repos;

        public CategoriesController(ICatagoryRepos catagoryRepos)
        {
            _repos = catagoryRepos;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {   
            var model = await _repos.GetAll();
            var categoryDto = model.Select(x => new CategoryDto()
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Status = x.Status,
            }).Where(x => x.Status == Status.Active); // để chỉ hiển thị active
            return Ok(categoryDto);
        }
        [HttpGet("{CategoryId}")]
        public async Task<IActionResult> GetById(Guid CategoryId)
        {
            var result = await _repos.GetById(CategoryId);
            if (result == null)
            {
                return NotFound($"Khong Tim Thay Id: {CategoryId}");
            }
            return Ok(new CategoryDto
            {
                CategoryId = CategoryId,
                CategoryName = result.CategoryName,
                Status = result.Status,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _repos.CreateNew(new Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = request.CategoryName,
                Status = Status.Active,
            });
            return Ok(result);
        }
        [HttpPatch("{categoryId}")]
        public async Task<IActionResult> Update(Guid categoryId,CategoryUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = await _repos.GetById(categoryId);
            if (model == null)
            {
                return BadRequest($"{categoryId} is not found");
            }
            model.CategoryName = request.CategoryName;
            model.Status = request.Status;
            var result = await _repos.Update(model);
            return Ok(new CategoryDto
            {
                CategoryId = result.CategoryId,
                CategoryName = result.CategoryName,
                Status = result.Status,
            });
        }
        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = await _repos.GetById(categoryId);
            if (model == null)
            {
                return BadRequest($"{categoryId} is not found");
            }
            model.Status = Status.InActive;
            var result = await _repos.Delete(model);
            return Ok(new CategoryDto
            {
                CategoryId = result.CategoryId,
                CategoryName = result.CategoryName,
                Status = result.Status,
            });
        }

    }
}
