using Book.Api.Entities;
using Book.Api.IRepositories;
using Book.Models.Dtos;
using Book.Models.Enums;
using Book.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Book.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        public IOrderDetailRepos _res;

        public OrderDetailsController(IOrderDetailRepos res)
        {
            _res = res;
        }
        [HttpGet]
        [Route("/OrderId")]
        public async Task<IActionResult> GetAll(Guid OrderId)
        {
            var result = await _res.GetAll(OrderId);
            if (result == null)
            {
                return NotFound($"Khong Tim Thay Id: {OrderId}");
            }
            var model = result.Select(x => new OrderDetailDto
            {
                OrderDetailId = x.OrderDetailId,
                Quantity = x.Quantity,
                Price = x.Price,
                ProductName = x.Product == null ? "N/A" : x.Product.ProductName,
                FullName = x.Order.UserId == null ? "N/A" : x.Order.User.FullName,
            });
            return Ok(model);
        }
        [HttpGet("{OrderDetailId}")]
        public async Task<IActionResult> GetById(Guid OrderDetailId)
        {
            var result = await _res.GetById(OrderDetailId);
            if (result == null)
            {
                return NotFound($"Khong Tim Thay Id: {OrderDetailId}");
            }
            return Ok(new OrderDetailDto
            {
                OrderDetailId = result.OrderDetailId,
                Quantity = result.Quantity,
                Price = result.Price,
                ProductName = result.Product == null ? "N/A" : result.Product.ProductName,
                FullName = result.Order.UserId == null ? "N/A" : result.Order.User.FullName,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderDetailCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _res.CreateNew(new OrderDetail
            {
                OrderDetailId = Guid.NewGuid(),
                Quantity = request.Quantity,
                Price = request.Price,
                ProductId = request.ProductId,
            });
            return Ok(result);
        }
        [HttpPatch("{OrderDetailId}")]
        public async Task<IActionResult> Update(Guid OrderDetailId, OrderDetailUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _res.GetById(OrderDetailId);
            if (result == null)
            {
                return NotFound($"Khong Tim Thay Id: {OrderDetailId}");
            }
            result.Quantity = request.Quantity;
            result.Price = request.Price;
            result.ProductId = result.ProductId;
            result.OrderId = result.OrderId;
            await _res.Update(result);
            return Ok(new OrderDetail
            {
                OrderDetailId = Guid.NewGuid(),
                Quantity = request.Quantity,
                Price = request.Price,
                ProductId = result.ProductId,
                OrderId = result.OrderId
            });
        }
        [HttpDelete("{OrderDetailId}")]
        public async Task<IActionResult> Delete(Guid OrderDetailId)
        {
            var result = await _res.GetById(OrderDetailId);
            if (result == null)
            {
                return NotFound($"Khong Tim Thay Id: {OrderDetailId}");
            }
            await _res.Delete(result);
            return Ok(result);
        }
    }
}
