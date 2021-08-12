using Microsoft.EntityFrameworkCore;

namespace login_example_SRA.EFDataAccess
{
    public class ApplicationDbContext : DbContext
    {
    
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Users> Users { get; set; }
    }
}