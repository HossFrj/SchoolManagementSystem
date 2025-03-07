
using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Endpoints;

namespace SMSystem.Core.RequestResponse.Students.Commands.Update;

public class UpdateStudentCommand : ICommand, IWebRequest
{
    public int Id { get; set; }
    public string SSN { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string Path => "/api/Student/Update";
}