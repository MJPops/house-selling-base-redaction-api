using HouseSellingBaseRedactionApi.Models;
using HouseSellingBaseRedactionApi.OtherData.PersonalExceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseSellingBaseRedactionApi.Interfaces
{
    public interface IUsersRepositore
    {
        /// <summary>
        /// Returns all users from the database.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="User"/></returns>
        /// <exception cref="NotFoundException"></exception>
        public Task<IEnumerable<User>> GetAllUsersAsync();
        /// <summary>
        /// Finds a user by ID in the database.
        /// </summary>
        /// <param name="userId">The id of the user being searched for.</param>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="User"/></returns>
        /// <exception cref="NotFoundException"></exception>
        public Task<User> GetUserByIdAsync(int userId);
        /// <summary>
        /// Adds a user to the database.
        /// </summary>
        /// <param name="user">The user to add.</param>
        public Task AddUserAsync(User user);
        /// <summary>
        /// Changes user data in the database according to the given object.
        /// </summary>
        /// <param name="user">New user model.</param>
        public Task UpdateUserAsync(User user);
        /// <summary>
        /// Deletes the user with the matching ID from the database.
        /// </summary>
        /// <param name="userId">The id of the user to be deleted.</param>
        /// <exception cref="NotFoundException"></exception>
        public Task RemoveUserAsync(int userId);
    }
}