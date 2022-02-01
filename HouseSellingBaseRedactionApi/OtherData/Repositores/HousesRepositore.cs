using HouseSellingBaseRedactionApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HouseSellingBaseRedactionApi.Interfaces;

namespace HouseSellingBaseRedactionApi.Repositores
{
    public class HousesRepositore : IHousesRepositore
    {
        private readonly AppDbContext _dbContext;
        public HousesRepositore(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<House>> GetAllHousesAsync()
        {
            return await _dbContext.Houses.ToListAsync();
        }
        public async Task<House> GetHouseById(int houseId)
        {
            return await _dbContext.Houses.FindAsync(houseId);
        }
        public async Task AddNewHouseAsync(House house)
        {
            await _dbContext.Houses.AddAsync(house);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateHouseAsync(House house)
        {
            _dbContext.Houses.Update(house);
            await _dbContext.SaveChangesAsync();
        }
        public async Task RemoveHouse(int houseId)
        {
            var house = await _dbContext.Houses.FindAsync(houseId);
            if (house == null)
            {
                throw new Exception();
            }
            _dbContext.Houses.Remove(house);
            await _dbContext.SaveChangesAsync();
        }
    }
}
