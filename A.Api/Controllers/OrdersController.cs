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
    public class OrdersController : ControllerBase
    {
        public IOrderRepos _res;

        public OrdersController(IOrderRepos res)
        {
            _res = res;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _res.GetAll();
            var model = result.Select(x => new OrderDto
            {
                OrderId = x.OrderId,
                Total = x.Total,
                DateTime = x.DateTime,
                OrderStatus = x.OrderStatus,
                UserFullName = x.User == null ? "N/A" : x.User.FullName,
                UserAddress = x.User == null ? "N/A" : x.User.Address,
            }).Where(x => x.OrderStatus == OrderStatus.Ordered || x.OrderStatus == OrderStatus.Success || x.OrderStatus == OrderStatus.Shipping);
            return Ok(model);
        }
        [HttpGet("{OrderId}")]
        public async Task<IActionResult> GetById(Guid OrderId)
        {
            var result = await _res.GetById(OrderId);
            if (result == null)
            {
                return NotFound($"Khong Tim Thay Id: {OrderId}");
            }
            return Ok(new OrderDto
            {
                OrderId = OrderId,
                Total = result.Total,
                DateTime = result.DateTime,
                OrderStatus = result.OrderStatus,
                UserFullName = result.User == null ? "N/A" : result.User.FullName,
                UserAddress = result.User == null ? "N/A" : result.User.Address,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _res.CreateNew(new Order
            {
                OrderId = Guid.NewGuid(),
                Total = request.Total,
                DateTime = DateTime.Now,
                OrderStatus = OrderStatus.Ordered,
            });
            return Ok(result);
        }
        [HttpPatch("{OrderId}")]
        public async Task<IActionResult> Update(Guid OrderId, OrderUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _res.GetById(OrderId);
            if (result == null)
            {
                return NotFound($"Khong Tim Thay Id: {OrderId}");
            }
            result.Total = request.Total;
            result.DateTime = DateTime.Now;
            result.OrderStatus = request.OrderStatus;
            await _res.Update(result);
            return Ok(result);
        }
        [HttpDelete("{OrderId}")]
        public async Task<IActionResult> Delete(Guid OrderId)
        {
            var result = await _res.GetById(OrderId);
            if (result == null)
            {
                return NotFound($"Khong Tim Thay Id: {OrderId}");
            }
            result.OrderStatus = OrderStatus.Canceled;
            await _res.Delete(result);
            return Ok(result);
        }
    }
}
