using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.RequestResponse.Endpoints;
using Zamin.Core.RequestResponse.Queries;

namespace SMSystem.Core.RequestResponse.Students.Queries.GetAll
{
    public class GetAllStudentByQuery : IQuery<StudentQr?>, IWebRequest
    {
        public int StudentId { get; set; }

        public string Path => "/api/Student/GetById";
    }
}
