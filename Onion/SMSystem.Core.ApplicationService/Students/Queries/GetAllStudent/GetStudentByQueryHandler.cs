using SMSystem.Core.RequestResponse.Students.Queries.Get;
using SMSystem.Core.RequestResponse.Students.Queries.GetAll;
using SMSystem.Core.Contracts.Students.Queries;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace SMSystem.Core.ApplicationService.Students.Queries.GetAllStudent;

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
