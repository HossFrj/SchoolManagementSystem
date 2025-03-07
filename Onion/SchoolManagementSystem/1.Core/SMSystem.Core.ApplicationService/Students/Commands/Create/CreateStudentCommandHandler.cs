﻿using SMSystem.Core.Contracts.Students.Commands;
using SMSystem.Core.Domain.Students.Entites;
using SMSystem.Core.RequestResponse.Students.Commands.Create;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
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
            Student studnet = Student.Create(command.SSN, command.FirstName, command.LastName);
            try
            {
                await _studentCommandRepository.InsertAsync(studnet);
                await _studentCommandRepository.CommitAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new InvalidEntityStateException("کد ملی تکراری !!!");
            }

            return Ok(studnet.BusinessId.Value);
        }
    }
}
