using Microsoft.AspNetCore.Mvc;
using SMSystem.Core.RequestResponse.Students.Queries.OutBoxEventItemQr;
using Zamin.EndPoints.Web.Controllers;

namespace SMSystem.APP.Server.OutBoxEventItem
{
    [Route("api/[controller]")]
    public class OutBoxEventItemController : BaseController
    {
        #region Queries

        [HttpGet("Get")]
        public async Task<IActionResult> GetAllOutBoxEventItems(GetOutBoxEventItemByQuery query) => await Query<GetOutBoxEventItemByQuery, List<OutBoxEventItemQr?>>(query);

        #endregion
    }
}
