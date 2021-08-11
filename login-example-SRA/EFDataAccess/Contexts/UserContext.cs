using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace login_example_SRA.EFDataAccess
{
    public class UserContext : DbContext
    {
    
        public UserContext() : base(@"Server=db;Database=master;User=sa;Password=Docker1!;")
        {
        }
        
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}