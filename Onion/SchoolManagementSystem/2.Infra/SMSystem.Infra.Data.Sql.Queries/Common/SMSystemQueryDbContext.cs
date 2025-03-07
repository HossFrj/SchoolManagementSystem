using Microsoft.EntityFrameworkCore;
using SMSystem.Infra.Data.Sql.Queries.OutBoxEvenItem;
using SMSystem.Infra.Data.Sql.Queries.Students;
using Zamin.Infra.Data.Sql.Queries;

namespace SMSystem.Infra.Data.Sql.Queries.Common
{
    public partial class SMSystemQueryDbContext : BaseQueryDbContext
    {
        public  SMSystemQueryDbContext(DbContextOptions<SMSystemQueryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<OutBoxEventItem> OutBoxEventItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OutBoxEventItem>()
                .ToTable("OutBoxEventItems", "zamin")
                .HasNoKey();
            modelBuilder.Entity<Student>()
               .ToTable("Students", "dbo")
               .HasNoKey();
        }
    }
}
