using Microsoft.EntityFrameworkCore;
using SMSystem.Core.Domain.Students.Entites;
using Zamin.Extensions.Events.Outbox.Dal.EF;

namespace SMSystem.Infra.Data.Sql.Commands.Common
{
    public class SMSystemCommandDbContext : BaseOutboxCommandDbContext
    {
        public DbSet<Student> Students { get; set; }
        public SMSystemCommandDbContext(DbContextOptions<SMSystemCommandDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
