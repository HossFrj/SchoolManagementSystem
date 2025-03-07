using Zamin.Core.RequestResponse.Endpoints;
using Zamin.Core.RequestResponse.Queries;

namespace SMSystem.Core.RequestResponse.Students.Queries.Get;

public class GetStudentByQuery : IQuery<List<StudentQr?>>, IWebRequest
{
    public string Path => "/api/Student/Get";
}