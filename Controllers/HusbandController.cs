using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using patrickLearn.CustomActionFilters;
using patrickLearn.DTOs.Husband;
using patrickLearn.Models;
using patrickLearn.Service;

namespace patrickLearn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HusbandController : ControllerBase
    { 
        private readonly IHusbandService _husbandService;

        public HusbandController(IHusbandService husbandService)
        {
            _husbandService = husbandService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetHusbandDTO>>>> GetAll([FromQuery] string? filterOn , [FromQuery] string? filterQuery)
        {
            return Ok(await _husbandService.GetAllHusband());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetHusbandDTO>>>> GetById(int id)
        {
            return Ok(await _husbandService.GetHusbandById(id));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult<ServiceResponse<List<GetHusbandDTO>>>> AddHusband(AddHusbandDTO newHusband)
        {
            // if (ModelState.IsValid)
            // {       
                return Ok(await _husbandService.AddHusband(newHusband));
            // }
            // else    return BadRequest(ModelState);
        }

         [HttpPut]
         [ValidateModel]
        public async Task<ActionResult<ServiceResponse<List<GetHusbandDTO>>>> UpdateHusband(UpdateHusbandDTO updateHusband)
        {   
            // if (ModelState.IsValid)
            //     {
                var response = await _husbandService.UpdateHusband(updateHusband);
                if (response.Data is null)
                {
                    return NotFound(response);                
                }
                return Ok(response);  
                // }
                //     else
                // return BadRequest(ModelState);
           
        }

          [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetHusbandDTO>>>> DeleteHusband(int id)
        {
             var response = await _husbandService.DeleteHusband(id);
            if (response.Data is null)
            {
                return NotFound(response);                
            }
            return Ok(response);
        }
    }
}