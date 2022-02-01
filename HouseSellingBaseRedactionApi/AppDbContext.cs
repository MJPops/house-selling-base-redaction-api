using HouseSellingBaseRedactionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseSellingBaseRedactionApi
{
    public class AppDbContext : DbContext
    {
        public DbSet<House> Houses { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
