using Business.Abstract;
using Core.RequestParameter;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Pagination pagination)
        {
            //var result = await _categoryService.GetAll();
            //if (result.Success)
            //{
            //    return Ok(result);
            //}
            //return BadRequest(result);

            var totalCount = _categoryService.GetAll().Result.Data.Count;
            var result = _categoryService.GetAll().Result.Data.Skip(pagination.Page * pagination.Size).Take(pagination.Size);
            return Ok(new
            {
                totalCount,
                result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category entity)
        {
            var result = await _categoryService.Add(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Category entity)
        {
            var result = await _categoryService.Delete(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Category entity)
        {
            var result = await _categoryService.Update(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getalltypes")]
        public async Task<IActionResult> GetAllTypes()
        {

            var result = await _categoryService.GetAll();
            if (result.Success)
            {
                return Ok(new { result.Data });
            }
            return BadRequest(result);
        }
    }
}
