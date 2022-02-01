using HouseSellingBaseRedactionApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseSellingBaseRedactionApi.Interfaces
{
    public interface IHousesRepositore
    {
        public Task<IEnumerable<House>> GetAllHousesAsync();
        public Task<House> GetHouseById(int houseId);
        public Task AddNewHouseAsync(House house);
        public Task UpdateHouseAsync(House house);
        public Task RemoveHouse(int houseId);
    }
}
