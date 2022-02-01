using HouseSellingBaseRedactionApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseSellingBaseRedactionApi.Interfaces
{
    public interface IUsersRepositore
    {
        public Task<IEnumerable<User>> GetAllUsersAsync();
    }
}