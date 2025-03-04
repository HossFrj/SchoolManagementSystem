using SMSystem.Core.Domain.Students.Entites;
using Zamin.Infra.Data.Sql.Commands;
using Zamin.Extensions.Events.Outbox.Dal.EF;
using SMSystem.Infra.Data.Sql.Commands.Common;
using SMSystem.Core.Contracts.Students.Commands;

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
