using SMSystem.Core.Domain.Students.Entites;
using Zamin.Core.Contracts.Data.Commands;

namespace SMSystem.Core.Contracts.Students.Commands
{
    public interface IStudentCommandRepository : ICommandRepository<Student, int>
    {
    }
}
