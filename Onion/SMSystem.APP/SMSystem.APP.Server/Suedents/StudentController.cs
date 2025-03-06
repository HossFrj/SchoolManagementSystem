using Microsoft.AspNetCore.Mvc;
using SMSystem.Core.RequestResponse.Students.Commands.Create;
using SMSystem.Core.RequestResponse.Students.Commands.Delete;
using SMSystem.Core.RequestResponse.Students.Commands.Update;
using SMSystem.Core.RequestResponse.Students.Queries;
using SMSystem.Core.RequestResponse.Students.Queries.GetAll;
using Zamin.EndPoints.Web.Controllers;

namespace SMSystem.APP.Server.Suedents
{
    [Route("api/[controller]")]
    public class StudentController : BaseController
    {
        #region Commands

        //[HttpGet("Get")]
        //public async Task<IActionResult> GetById(StudentQuery query) => await Query<StudentQuery, GetStudentCommandQuery?>(query);

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(GetAllStudentByQuery query)
        {
            return await Query<GetAllStudentByQuery, StudentQr?>(query);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateBlog([FromBody] CreateStudentCommand command) => await Create<CreateStudentCommand, Guid>(command);

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateBlog([FromBody] UpdateStudentCommand command) => await Edit(command);

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteBlog([FromBody] DeleteStudentCommand command) => await Delete(command);

        //[HttpGet("GetById")]
        //public async Task<IActionResult> GetById(GetAllStudentByQuery query) => await Query<GetAllStudentByQuery, StudentQr?>(query);
        #endregion


    }
}
