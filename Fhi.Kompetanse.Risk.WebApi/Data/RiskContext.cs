using Microsoft.EntityFrameworkCore;
using Fhi.Kompetanse.Risk.Domenemodell.Entities;

namespace Fhi.Kompetanse.Risk.WebApi.Data
{
    public class RiskContext : DbContext
    {
        public RiskContext(DbContextOptions<RiskContext> options)
            : base(options)
        {
        }

        public DbSet<RiskSpill> RiskSpill { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RiskSpill>(entity =>
            {
                entity.ToTable("RiskSpill", "Risk");
                entity.Property<DateTime>("Opprettet").ValueGeneratedOnAdd().HasDefaultValueSql("getdate()"); ;
                entity.Property(job => job.RiskSpillStatus).HasConversion<string>();
            });
        }
    }
}
