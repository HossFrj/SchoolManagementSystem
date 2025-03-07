using SMSystem.Core.RequestResponse.Students.Queries.GetAll;
using SMSystem.Core.RequestResponse.Students.Queries.OutBoxEventItemQr;
namespace SMSystem.Core.Contracts.Students.Queries;

public interface IOutBoxEventItemQueryRepository
{
    public Task<List<OutBoxEventItemQr?>> ExecuteAsync(GetOutBoxEventItemByQuery query);
}