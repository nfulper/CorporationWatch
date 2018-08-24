using Microsoft.EntityFrameworkCore;

namespace CorpWatchApi.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
    }
}