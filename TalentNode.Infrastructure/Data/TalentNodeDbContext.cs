using Microsoft.EntityFrameworkCore;
using TalentNode.Domain.Entities;


namespace TalentNode.Infrastructure.Data
{
    public class TalentNodeDbContext(DbContextOptions<TalentNodeDbContext> Options):DbContext(Options)
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<FoodCategoryMaster> FoodCategoryMaster { get; set; }
        public DbSet<FoodMenu> FoodMenu { get; set; }

        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<RoleMaster> RoleMaster { get; set; }
        public DbSet<UserRoleMapping> UserRoleMapping { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite keys
            modelBuilder.Entity<UserRoleMapping>()
            .HasKey(urm => new { urm.UserName, urm.RoleId });

            base.OnModelCreating(modelBuilder);
        }

    }
}
