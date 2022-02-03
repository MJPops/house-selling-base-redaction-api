using HouseSellingBaseRedactionApi.Models;
using HouseSellingBaseRedactionApi.OtherData.PersonalExceptions;
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
        /// <exception cref="NotFoundException"></exception>
        public Task<IEnumerable<House>> GetAllHousesAsync();
        /// <summary>
        /// Returns the house with the given Id from the database.
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns><see cref="House"/></returns>
        /// <exception cref="NotFoundException"></exception>
        public Task<House> GetHouseByIdAsync(int houseId);
        /// <summary>
        /// Adds a house to the database.
        /// </summary>
        /// <param name="house">Added house.</param>
        /// <exception cref="AlreadyContainsException"></exception>
        public Task AddNewHouseAsync(House house);
        /// <summary>
        /// Update the house model in the database.
        /// </summary>
        /// <param name="house">New house model.</param>
        /// <exception cref="NotFoundException"></exception>
        public Task UpdateHouseAsync(House house);
        /// <summary>
        /// Removes the house from the database with the given Id.
        /// </summary>
        /// <param name="houseId">The ID of the house to be deleted.</param>
        /// <exception cref="NotFoundException"></exception>
        public Task RemoveHouseAsync(int houseId);
    }
}
