using HouseSellingBaseRedactionApi.Interfaces;
using HouseSellingBaseRedactionApi.Models;
using HouseSellingBaseRedactionApi.OtherData.PersonalExceptions;
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
                return NotFound();
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
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(House house)
        {
            try
            {
                await _housesRepositore.AddNewHouseAsync(house);
                return Ok();
            }
            catch (AlreadyContainsException)
            {
                return Conflict();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(House house)
        {
            await _housesRepositore.UpdateHouseAsync(house);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _housesRepositore.RemoveHouse(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
