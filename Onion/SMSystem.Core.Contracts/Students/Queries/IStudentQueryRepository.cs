using SMSystem.Core.RequestResponse.Students.Queries.Get;
using SMSystem.Core.RequestResponse.Students.Queries.GetAll;
namespace SMSystem.Core.Contracts.Students.Queries;

public interface IStudentQueryRepository
{
    //public Task<StudentQr?> ExecuteAsync(GetStudentByQuery query);
    public Task<List<StudentQr?>> ExecuteAsync(GetStudentByQuery query);
}