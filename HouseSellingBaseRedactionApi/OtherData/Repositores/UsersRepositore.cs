using HouseSellingBaseRedactionApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using HouseSellingBaseRedactionApi.Interfaces;
using System;

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
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception();
            }
            await _dbContext.Houses.Include(h => h.Users).ToListAsync();
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
                throw new Exception();
            }
            _dbContext.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

    }
}
