using Business.Abstract;
using Core.RequestParameter;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var result = await _bookService.GetAll();
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllDetails([FromQuery] Pagination pagination)
        {
            var totalCount = _bookService.GetAllDetailsDto().Result.Data.Count();
            var result = _bookService.GetAllDetailsDto().Result.Data.Skip(pagination.Page * pagination.Size)
            .Take(pagination.Size);

            return Ok(new
            {
                totalCount,
                result
            });

        }

        [HttpPost]
        public async Task<IActionResult> Add(Book entity)
        {
            var result = await _bookService.Add(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Book entity)
        {
            var result = await _bookService.Delete(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Book entity)
        {
            var result = await _bookService.Update(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
