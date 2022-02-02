using HouseSellingBaseRedactionApi.Interfaces;
using HouseSellingBaseRedactionApi.Models;
using HouseSellingBaseRedactionApi.OtherData.PersonalExceptions;
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
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            try
            {
                return new ObjectResult(await _userRepositore.GetAllUsersAsync());
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            try
            {
                return new ObjectResult(await _userRepositore.GetUserByIdAsync(id));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(User user)
        {
            await _userRepositore.UpdateUserAsync(user);
            return Ok();
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
