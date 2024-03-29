﻿using Business.Abstract;
using Core.RequestParameter;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Pagination pagination)
        {
            //var result = await _storeService.GetAll();
            //if (result.Success)
            //{
            //    return Ok(result);
            //}
            //return BadRequest(result);

            var totalCount = _storeService.GetAll().Result.Data.Count;
            var result = _storeService.GetAll().Result.Data.Skip(pagination.Page * pagination.Size).Take(pagination.Size);
            return Ok(new
            {
                totalCount,
                result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Store store)
        {
            var result = await _storeService.Add(store);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Store entity)
        {
            var result = await _storeService.Delete(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Store entity)
        {
            var result = await _storeService.Update(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getalltypes")]
        public async Task<IActionResult> GetAllTypes()
        {

            var result = await _storeService.GetAll();
            if (result.Success)
            {
                return Ok(new { result.Data });
            }
            return BadRequest(result);
        }

    }
}
