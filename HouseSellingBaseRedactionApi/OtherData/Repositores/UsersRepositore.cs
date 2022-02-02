using HouseSellingBaseRedactionApi.Interfaces;
using HouseSellingBaseRedactionApi.Models;
using HouseSellingBaseRedactionApi.OtherData.PersonalExceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseSellingBaseRedactionApi.Repositores
{
    public class UsersRepositore : IUsersRepositore
    {
        private readonly AppDbContext _dbContext;
        public UsersRepositore(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _dbContext.Users.ToListAsync();
            if (users == null)
            {
                throw new NotFoundException();
            }
            return users;
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new NotFoundException();
            }
            return user;
        }
        public async Task UpdateUserAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
        public async Task RemoveUserAsync(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new NotFoundException();
            }
            _dbContext.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

    }
}
