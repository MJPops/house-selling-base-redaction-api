using HouseSellingBaseRedactionApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HouseSellingBaseRedactionApi.Interfaces;

namespace HouseSellingBaseRedactionApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepositore _userRepositore;
        public UsersController(IUsersRepositore usersRepositore)
        {
            _userRepositore = usersRepositore;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepositore.GetAllUsersAsync();
        }
    }
}
