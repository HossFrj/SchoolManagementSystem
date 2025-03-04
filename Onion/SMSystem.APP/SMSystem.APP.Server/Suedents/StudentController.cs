using Microsoft.AspNetCore.Mvc;
using Zamin.EndPoints.Web.Controllers;

namespace SMSystem.APP.Server.Suedents
{
    [Route("api/[controller]")]
    public class StudentController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlogCommand command) => await Create<CreateBlogCommand, Guid>(command);
    }
}
