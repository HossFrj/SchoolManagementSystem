using SMSystem.Core.Domain.Students.Entites;
using SMSystem.Core.RequestResponse.Students.Queries;
using SMSystem.Core.RequestResponse.Students.Queries.GetAll;

namespace SMSystem.Core.Contracts.Students.Queries
{
    public interface IStuedntQueryRepository
    {
        public Task<StudentQr?> ExecuteAsync(GetAllStudentByQuery query);
    }
}
