using CorpWatchApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CorpWatchApi.Models
{
    public class ApplicationDbContext : DbContext
    {
       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<Employee> Employees {get; set; }
        public DbSet<Job> Jobs {get; set; }

    }
}