using HouseSellingBaseRedactionApi.Interfaces;
using HouseSellingBaseRedactionApi.Models;
using HouseSellingBaseRedactionApi.OtherData.PersonalExceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
                return NotFound("The users have not been added to the database.");
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
                return NotFound("No user with this ID was found.");
            }
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Add(User user)
        {
            try
            {
                await _userRepositore.AddUserAsync(user);
                return Ok("User added");
            }
            catch (AlreadyContainsException)
            {
                return NotFound("This user has already been added to the database.");
            }
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Put(User user)
        {
            try
            {
                await _userRepositore.UpdateUserAsync(user);
                return Ok("User updated");
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> SetAdminRole(int id)
        {
            try
            {
                var user = await _userRepositore.GetUserByIdAsync(id);
                user.Role = "admin";
                await _userRepositore.UpdateUserAsync(user);
                return Ok("User is admin");
            }
            catch (NotFoundException)
            {
                return NotFound("No user with this ID was found.");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _userRepositore.RemoveUserAsync(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound("No user with this ID was found.");
            }
        }

    }
}
