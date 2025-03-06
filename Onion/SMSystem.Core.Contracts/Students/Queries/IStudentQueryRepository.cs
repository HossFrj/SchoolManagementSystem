using SMSystem.Core.RequestResponse.Students.Queries.Get;
namespace SMSystemMiniBlog.Core.Contracts.Blogs.Queries;

public interface IStudentQueryRepository
{
    //public Task<StudentQr?> ExecuteAsync(GetStudentByQuery query);
    public Task<List<StudentQr?>> ExecuteAsync(GetStudentByQuery query);
}