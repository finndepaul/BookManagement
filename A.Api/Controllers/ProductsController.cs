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
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepos _repos;

        public ProductsController(IProductRepos repos)
        {
            _repos = repos;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repos.GetAll();
            var Model = products.Select(x => new ProductDto
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Description = x.Description,
                Price = x.Price,
                SalePrice = x.SalePrice,
                status = x.Status,
                CategoryName = x.Category == null ? "N/A" : x.Category.CategoryName
            });
            return Ok(Model);
        }
        [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetById(Guid ProductId)
        {
            var result = await _repos.GetById(ProductId);
            if (result == null)
            {
                return BadRequest($"{ProductId} is not found");
            }
            return Ok(new ProductDto
            {
                ProductId = result.ProductId,
                ProductName = result.ProductName,
                Description = result.Description,
                Price = result.Price,
                SalePrice = result.SalePrice,
                status = result.Status,
                CategoryName = result.CategoryId == null ? "N/A" : result.Category.CategoryName,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = await _repos.CreateNew(new Product
            {
                ProductId = Guid.NewGuid(),
                ProductName = request.ProductName,
                Description = request.Description,
                Price = request.Price,
                SalePrice = request.SalePrice,
                Status = Status.Active,
                CategoryId = request.CategoryId,
            });
            return Ok(model);
        }
        [HttpPatch("{ProductId}")]
        public async Task<IActionResult> Update(Guid ProductId, ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = await _repos.GetById(ProductId);
            if (model == null)
            {
                return BadRequest($"{ProductId} is not found");
            }
            model.ProductName = request.ProductName;
            model.Description = request.Description;
            model.Price = request.Price;
            model.SalePrice = request.SalePrice;
            model.Status = request.Status;
            model.CategoryId = request.CategoryId;
            var result = await _repos.Update(model);
            return Ok(new ProductDto
            {
                ProductId = ProductId,
                ProductName = result.ProductName,
                Description = result.Description,
                Price = result.Price,
                SalePrice = result.SalePrice,
                status = result.Status,
                CategoryName = result.Category == null ? "N/A" : result.Category.CategoryName
            });
        }
        [HttpDelete("{ProductId}")]
        public async Task<IActionResult> Delete(Guid ProductId)
        {
            var result = await _repos.GetById(ProductId);
            if (result == null)
            {
                return BadRequest($"{ProductId} is not found");
            }
            await _repos.Delete(result);
            return Ok(new ProductDto
            {
                ProductId = ProductId,
                ProductName = result.ProductName,
                Description = result.Description,
                Price = result.Price,
                SalePrice = result.SalePrice,
                status = result.Status,
                CategoryName = result.Category == null ? "N/A" : result.Category.CategoryName
            });
        }

    }
}
