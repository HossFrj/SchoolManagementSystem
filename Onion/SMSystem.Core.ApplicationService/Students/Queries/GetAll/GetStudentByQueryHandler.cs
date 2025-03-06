using SMSystem.Core.RequestResponse.Students.Queries.Get;
using SMSystemMiniBlog.Core.Contracts.Blogs.Queries;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace SMSystem.Core.ApplicationService.Students.Queries.Get;

public class GetStudentByQueryHandler : QueryHandler<GetStudentByQuery, List<StudentQr?>>
{
    private readonly IStudentQueryRepository _studentQueryRepository;

    public GetStudentByQueryHandler(ZaminServices zaminServices,
                                   IStudentQueryRepository studentQueryRepository) : base(zaminServices)
    {
        _studentQueryRepository = studentQueryRepository;
    }

    public override async Task<QueryResult<List<StudentQr?>>> Handle(GetStudentByQuery query)
    {
        var student = await _studentQueryRepository.ExecuteAsync(query);

        return Result(student);
    }
}
