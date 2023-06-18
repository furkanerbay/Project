using Business.Abstract;
using Core.RequestParameter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
    }


        [HttpGet]
        public IActionResult GetAll([FromQuery] Pagination pagination)
        {
            var totalCount = _userService.GetAll().Result.Data.Count();
            var result = _userService.GetAll().Result.Data.Skip(pagination.Page * pagination.Size)
                .Take(pagination.Size);

            return Ok(new
            {
                totalCount,
                result
            });
        }

        [HttpGet("getalltypes")]
        public async Task<IActionResult> GetAllTypes()
        {

            var result = await _userService.GetAll();
            if (result.Success)
            {
                return Ok(new { result.Data });
            }
            return BadRequest(result);
        }
    }
}
