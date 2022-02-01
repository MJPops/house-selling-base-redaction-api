using HouseSellingBaseRedactionApi.Interfaces;
using HouseSellingBaseRedactionApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpPut("{userId}")]
        public async Task<IActionResult> SetAdminRole(int userId)
        {
            try
            {
                var user = await _userRepositore.GetUserByIdAsync(userId);
                user.Role = "admin";
                await _userRepositore.UpdateUserAsync(user);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUsers(int userId)
        {
            try
            {
                await _userRepositore.RemoveUserAsync(userId);
                return Ok();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

    }
}
