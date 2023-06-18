using Business.Abstract;
using Core.RequestParameter;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Pagination pagination)
        {
            //var result = await _colorService.GetAll();
            //if(result.Success)
            //{
            //    return Ok(result);
            //}
            //return BadRequest(result);

            var totalCount = _colorService.GetAll().Result.Data.Count;
            var result = _colorService.GetAll().Result.Data.Skip(pagination.Page * pagination.Size).Take(pagination.Size);

            return Ok(new
            {
                totalCount,
                result
            });

        }

        [HttpPost]
        public async Task<IActionResult> Add(Color entity)
        {
            var result = await _colorService.Add(entity);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Color entity)
        {
            var result = await _colorService.Delete(entity);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); 
        }
        [HttpPut]
        public async Task<IActionResult> Update(Color entity)
        {
            var result = await _colorService.Update(entity);
            if (result.Success)
            {
                return Ok(result);
            }    
            return BadRequest(result);
        }

        [HttpGet("getalltypes")]
        public async Task<IActionResult> GetAllTypes()
        {

            var result = await _colorService.GetAll();
            if (result.Success)
            {
                return Ok(new { result.Data });
            }
            return BadRequest(result);
        }

    }
}
