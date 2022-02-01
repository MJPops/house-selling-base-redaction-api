using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HouseSellingBaseRedactionApi.Interfaces;
using HouseSellingBaseRedactionApi.Models;

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
        public async Task<IEnumerable<House>> Get()
        {
            return await _housesRepositore.GetAllHousesAsync();
        }
        [HttpGet("{id}")]
        public async Task<House> Get(int id)
        {
            return await _housesRepositore.GetHouseById(id);
        }

        [HttpPost]
        public async Task Add(House house)
        {
            await _housesRepositore.AddNewHouseAsync(house);
        }

        [HttpPut]
        public async Task Put(House house)
        {
            await _housesRepositore.UpdateHouseAsync(house);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _housesRepositore.RemoveHouse(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
