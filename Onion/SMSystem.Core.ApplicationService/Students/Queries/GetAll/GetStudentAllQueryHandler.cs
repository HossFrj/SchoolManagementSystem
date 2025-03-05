using SMSystem.Core.Contracts.Students.Queries;
using SMSystem.Core.RequestResponse.Students.Queries;
using SMSystem.Core.RequestResponse.Students.Queries.GetAll;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace SMSystem.Core.ApplicationService.Students.Queries.GetAll
{
    public class GetStudentAllQueryHandler  : QueryHandler<GetAllStudentByQuery, StudentQr?>
    {
        private readonly IStuedntQueryRepository _studentQueryRepository;

        public GetStudentAllQueryHandler(ZaminServices zaminServices,
                                       IStuedntQueryRepository studentQueryRepository) : base(zaminServices)
        {
            _studentQueryRepository = studentQueryRepository;
        }

        public override async Task<QueryResult<StudentQr?>> Handle(GetAllStudentByQuery query)
        {
            var blog = await _studentQueryRepository.ExecuteAsync(query);

            return Result(blog);
        }
    }
}
