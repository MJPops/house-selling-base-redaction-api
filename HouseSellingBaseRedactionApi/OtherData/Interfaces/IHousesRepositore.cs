using HouseSellingBaseRedactionApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseSellingBaseRedactionApi.Interfaces
{
    public interface IHousesRepositore
    {
        /// <summary>
        /// Returns all houses from the database.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="House"/></returns>
        public Task<IEnumerable<House>> GetAllHousesAsync();
        /// <summary>
        /// Returns the house with the given Id from the database.
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns><see cref="House"/></returns>
        public Task<House> GetHouseById(int houseId);
        /// <summary>
        /// Adds a house to the database.
        /// </summary>
        /// <param name="house">Added house.</param>
        public Task AddNewHouseAsync(House house);
        /// <summary>
        /// Update the house model in the database.
        /// </summary>
        /// <param name="house">New house model.</param>
        public Task UpdateHouseAsync(House house);
        /// <summary>
        /// Removes the house from the database with the given Id.
        /// </summary>
        /// <param name="houseId">The ID of the house to be deleted.</param>
        /// <exception cref="System.Exception"></exception>
        public Task RemoveHouse(int houseId);
    }
}
