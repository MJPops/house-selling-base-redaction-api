using HouseSellingBaseRedactionApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using HouseSellingBaseRedactionApi.Interfaces;

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
    }
}
