using SMSystem.Core.Contracts.Students.Commands;
using SMSystem.Core.Domain.Students.Entites;
using SMSystem.Core.RequestResponse.Students.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace SMSystem.Core.ApplicationService.Students.Commands.Create
{
    public class CreateStudentCommandHandler : CommandHandler<CreateStudentCommand, Guid>
    {
        private readonly IStudentCommandRepository _studentCommandRepository;
        public CreateStudentCommandHandler(ZaminServices zaminServices,
                                    IStudentCommandRepository studentCommandRepository) : base(zaminServices)
        {
            _studentCommandRepository = studentCommandRepository;
        }
        public override async Task<CommandResult<Guid>> Handle(CreateStudentCommand command)
        {
            Student blog = Student.Create(command.SSN, command.FirstName , command.LastName);

            await _studentCommandRepository.InsertAsync(blog);

            await _studentCommandRepository.CommitAsync();

            return Ok(blog.BusinessId.Value);
        }
    }
}
