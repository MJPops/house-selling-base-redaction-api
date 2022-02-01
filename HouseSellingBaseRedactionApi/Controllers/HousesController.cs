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
        public async Task<IEnumerable<House>> GetHouses()
        {
            return await _housesRepositore.GetAllHousesAsync();
        }
        [HttpGet("{houseId}")]
        public async Task<House> GetHouses(int houseId)
        {
            return await _housesRepositore.GetHouseById(houseId);
        }

        [HttpPost]
        public async Task AddNewHouse(House house)
        {
            await _housesRepositore.AddNewHouseAsync(house);
        }

        [HttpPut]
        public async Task PutHouse(House house)
        {
            await _housesRepositore.UpdateHouseAsync(house);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHouse(int id)
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
