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
        public async Task<IEnumerable<User>> Get()
        {
            return await _userRepositore.GetAllUsersAsync();
        }
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _userRepositore.GetUserByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SetAdminRole(int id)
        {
            try
            {
                var user = await _userRepositore.GetUserByIdAsync(id);
                user.Role = "admin";
                await _userRepositore.UpdateUserAsync(user);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _userRepositore.RemoveUserAsync(id);
                return Ok();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

    }
}
