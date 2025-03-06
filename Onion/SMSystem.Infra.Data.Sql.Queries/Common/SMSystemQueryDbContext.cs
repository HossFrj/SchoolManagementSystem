using Microsoft.EntityFrameworkCore;
using SMSystem.Infra.Data.Sql.Queries.Students;
using Zamin.Infra.Data.Sql.Queries;

namespace SMSystem.Infra.Data.Sql.Queries.Common
{
    public partial class SMSystemQueryDbContext : BaseQueryDbContext
    {
        public SMSystemQueryDbContext(DbContextOptions<SMSystemQueryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<OutBoxEventItem> OutBoxEventItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=.;Database=SMSystemDb;Integrated Security=True;TrustServerCertificate=True");
                optionsBuilder.UseSqlServer("Server =.; Database = MiniBlogDb; User Id =sa; Password= 1qaz!QAZ; MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OutBoxEventItem>(entity =>
            {
                entity.Property(e => e.AccuredByUserId).HasMaxLength(255);

                entity.Property(e => e.AggregateName).HasMaxLength(255);

                entity.Property(e => e.AggregateTypeName).HasMaxLength(500);

                entity.Property(e => e.EventName).HasMaxLength(255);

                entity.Property(e => e.EventTypeName).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
