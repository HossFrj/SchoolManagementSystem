using Microsoft.AspNetCore.Mvc;
using SMSystem.Core.RequestResponse.Students.Commands.Create;
using SMSystem.Core.RequestResponse.Students.Commands.Delete;
using SMSystem.Core.RequestResponse.Students.Commands.Update;
using SMSystem.Core.RequestResponse.Students.Queries.Get;
using SMSystem.Core.RequestResponse.Students.Queries.GetAll;
using Zamin.EndPoints.Web.Controllers;

namespace SMSystem.APP.Server.Suedents
{
    [Route("api/[controller]")]
    public class StudentController : BaseController
    {
        #region Commands
        [HttpPost("Create")]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command) => await Create<CreateStudentCommand, Guid>(command);

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand command) => await Edit(command);

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteStudent([FromBody] DeleteStudentCommand command) => await Delete(command);

        [HttpGet("Get")]
        public async Task<IActionResult> GetAllStudents(GetStudentByQuery query) => await Query<GetStudentByQuery, List<StudentQr?>>(query);
        #endregion


    }
}
