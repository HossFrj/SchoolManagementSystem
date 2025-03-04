using SMSystem.Core.Domain.Students.Entites;
using Zamin.Infra.Data.Sql.Commands;
using Zamin.Extensions.Events.Outbox.Dal.EF;
using SMSystem.Core.Contracts.Students;
using SMSystem.Infra.Data.Sql.Commands.Common;

namespace SMSystem.Infra.Data.Sql.Commands.Students
{
    public class StudnetCommandRepository : BaseCommandRepository<Student, SMSystemCommandDbContext, int>,
        IStudentCommandRepository
    {
        public StudnetCommandRepository(SMSystemCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
