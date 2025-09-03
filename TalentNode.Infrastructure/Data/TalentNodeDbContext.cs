using Microsoft.EntityFrameworkCore;


namespace TalentNode.Infrastructure.Data
{
    public class TalentNodeDbContext(DbContextOptions<TalentNodeDbContext> Options):DbContext(Options)
    {
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite keys
           

            base.OnModelCreating(modelBuilder);
        }

    }
}
