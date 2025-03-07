using SMSystem.Core.RequestResponse.Students.Queries.GetAll;
using Zamin.Core.RequestResponse.Endpoints;
using Zamin.Core.RequestResponse.Queries;

namespace SMSystem.Core.RequestResponse.Students.Queries.OutBoxEventItemQr;

public class GetOutBoxEventItemByQuery : IQuery<List<OutBoxEventItemQr?>>, IWebRequest
{
    public string Path => "/api/OutBoxEventItem/Get";
}