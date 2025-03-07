using SMSystem.Core.RequestResponse.Students.Queries.Get;
using SMSystem.Core.RequestResponse.Students.Queries.GetAll;
using SMSystem.Core.Contracts.Students.Queries;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;
using SMSystem.Core.RequestResponse.Students.Queries.OutBoxEventItemQr;

namespace SMSystem.Core.ApplicationService.Students.Queries.OutBoxEventItem;

public class GetOutBoxEventItemQueryHandler : QueryHandler<GetOutBoxEventItemByQuery, List<OutBoxEventItemQr?>>
{
    private readonly IOutBoxEventItemQueryRepository _outBoxEventItemQueryRepository;

    public GetOutBoxEventItemQueryHandler(ZaminServices zaminServices,
                                   IOutBoxEventItemQueryRepository outBoxEventItemQueryRepository) : base(zaminServices)
    {
        _outBoxEventItemQueryRepository = outBoxEventItemQueryRepository;
    }

    public override async Task<QueryResult<List<OutBoxEventItemQr?>>> Handle(GetOutBoxEventItemByQuery query)
    {
        var eventItem = await _outBoxEventItemQueryRepository.ExecuteAsync(query);

        return Result(eventItem);
    }
}
