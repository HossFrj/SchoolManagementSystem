using SMSystem.Core.Domain.Students.Entites;
using Zamin.Infra.Data.Sql.Commands;
using Zamin.Extensions.Events.Outbox.Dal.EF;
using SMSystem.Infra.Data.Sql.Commands.Common;
using SMSystem.Core.Contracts.Students.Commands;

namespace SMSystem.Infra.Data.Sql.Commands.Students
{
    public class StudentCommandRepository : BaseCommandRepository<Student, SMSystemCommandDbContext, int>,
        IStudentCommandRepository
    {
        public StudentCommandRepository(SMSystemCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
