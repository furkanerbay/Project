using Business.Abstract;
using Core.RequestParameter;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService _provinceService;

        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Pagination pagination)
        {
            //var result = await _provinceService.GetAll();
            //if (result.Success)
            //{
            //    return Ok(result);
            //}
            //return BadRequest(result);

            var totalCount = _provinceService.GetAll().Result.Data.Count;
            var result = _provinceService.GetAll().Result.Data.Skip(pagination.Page * pagination.Size).Take(pagination.Size);

            return Ok(new
            {
                totalCount,
                result
            });

        }

        [HttpPost]
        public async Task<IActionResult> Add(Province entity)
        {
            var result = await _provinceService.Add(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Province entity)
        {
            var result = await _provinceService.Delete(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Province entity)
        {
            var result = await _provinceService.Update(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getalltypes")]
        public async Task<IActionResult> GetAllTypes()
        {

            var result = await _provinceService.GetAll();
            if (result.Success)
            {
                return Ok(new { result.Data });
            }
            return BadRequest(result);
        }
    }
}
