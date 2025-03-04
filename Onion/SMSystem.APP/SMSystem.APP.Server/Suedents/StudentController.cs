using Microsoft.AspNetCore.Mvc;
using MiniSMSystem.Core.RequestResponse.Students.Commands.Delete;
using MiniSMSystem.Core.RequestResponse.Students.Commands.Get;
using SMSystem.Core.RequestResponse.Students.Commands.Create;
using SMSystem.Core.RequestResponse.Students.Commands.Update;
using Zamin.EndPoints.Web.Controllers;

namespace SMSystem.APP.Server.Suedents
{
    [Route("api/[controller]")]
    public class StudentController : BaseController
    {
        #region Commands

        [HttpGet("Get")]
        public async Task<IActionResult> GetStudents(List<GetStudentCommand> command) => Ok(await Task.FromResult(command));

        [HttpPost("Create")]
        public async Task<IActionResult> CreateBlog([FromBody] CreateStudentCommand command) => await Create<CreateStudentCommand, Guid>(command);

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateBlog([FromBody] UpdateStudentCommand command) => await Edit(command);

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteBlog([FromBody] DeleteStudentCommand command) => await Delete(command);


        #endregion


    }
}
