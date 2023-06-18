using Business.Abstract;
using Core.RequestParameter;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Pagination pagination)
        {
            //var result = await _orderService.GetAll();
            //if (result.Success)
            //{
            //    return Ok(result);
            //}
            //return BadRequest(result);

            var totalCount = _orderService.GetAllDetailsDto().Result.Data.Count;
            var result = _orderService.GetAllDetailsDto().Result.Data.Skip(pagination.Page * pagination.Size).Take(pagination.Size);
            return Ok(new
            {
                totalCount,
                result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Order order)
        {
            var result = await _orderService.Add(order);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Order order)
        {
            var result = await _orderService.Delete(order);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        //[HttpPut]
        //public async Task<IActionResult> Update(Order order)
        //{
        //    var result = await _orderService.Update(order);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        [HttpPut]
        public  IActionResult Update(Order order)
        {
            var result = _orderService.UpdateNotAsync(order);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
