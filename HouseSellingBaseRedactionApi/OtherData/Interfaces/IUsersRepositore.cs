using HouseSellingBaseRedactionApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseSellingBaseRedactionApi.Interfaces
{
    public interface IUsersRepositore
    {
        public Task<IEnumerable<User>> GetAllUsersAsync();
        public Task<User> GetUserByIdAsync(int userId);
        public Task UpdateUserAsync(User user);
        public Task RemoveUserAsync(int userId);
    }
}