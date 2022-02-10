using HouseSellingBaseRedactionApi.Interfaces;
using HouseSellingBaseRedactionApi.Models;
using HouseSellingBaseRedactionApi.OtherData.PersonalExceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseSellingBaseRedactionApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly IHousesRepositore _housesRepositore;
        public HousesController(IHousesRepositore housesRepositore)
        {
            _housesRepositore = housesRepositore;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<House>>> Get()
        {
            try
            {
                return new ObjectResult(await _housesRepositore.GetAllHousesAsync());
            }
            catch (NotFoundException)
            {
                return NotFound("Houses not added to the database.");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<House>> Get(int id)
        {
            try
            {
                return new ObjectResult(await _housesRepositore.GetHouseByIdAsync(id));
            }
            catch (NotFoundException)
            {
                return NotFound("Houses with this ID are not added to the database.");
            }
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Add(House house)
        {
            try
            {
                await _housesRepositore.AddNewHouseAsync(house);
                return Ok();
            }
            catch (AlreadyContainsException)
            {
                return Conflict("This house has already been added to the database.");
            }
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Put(House house)
        {
            try
            {
                await _housesRepositore.UpdateHouseAsync(house);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound("The house with this ID was not found in the database.");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _housesRepositore.RemoveHouseAsync(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound("The house with this ID was not found in the database.");
            }
        }
    }
}
