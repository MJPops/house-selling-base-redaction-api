using HouseSellingBaseRedactionApi.Interfaces;
using HouseSellingBaseRedactionApi.Models;
using HouseSellingBaseRedactionApi.OtherData.PersonalExceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseSellingBaseRedactionApi.OtherData.Repositores
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
            var houses = await _dbContext.Houses.ToListAsync();
            if (houses == null)
            {
                throw new NotFoundException();
            }
            await _dbContext.Users.Include(u => u.FavoriteHouses).ToListAsync();
            return houses;
        }
        public async Task<House> GetHouseByIdAsync(int houseId)
        {
            var house = await _dbContext.Houses.FindAsync(houseId);
            if (house == null)
            {
                throw new NotFoundException();
            }
            await _dbContext.Users.Include(u => u.FavoriteHouses).ToListAsync();
            return house;
        }
        public async Task AddNewHouseAsync(House house)
        {
            try
            {
                await _dbContext.Houses.AddAsync(house);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new AlreadyContainsException();
            }
        }
        public async Task UpdateHouseAsync(House house)
        {
            _dbContext.Entry(house).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task RemoveHouseAsync(int houseId)
        {
            var house = await _dbContext.Houses.FindAsync(houseId);
            if (house == null)
            {
                throw new NotFoundException();
            }
            _dbContext.Houses.Remove(house);
            await _dbContext.SaveChangesAsync();
        }
    }
}
