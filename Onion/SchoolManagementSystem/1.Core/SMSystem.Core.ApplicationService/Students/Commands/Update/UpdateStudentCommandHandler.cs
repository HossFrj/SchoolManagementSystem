using SMSystem.Core.Contracts.Students.Commands;
using SMSystem.Core.RequestResponse.Students.Commands.Update;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace MiniBlog.Core.ApplicationService.Blogs.Commands.Update;

public sealed class UpdateStudentCommandHandler : CommandHandler<UpdateStudentCommand>
{
    private readonly IStudentCommandRepository _studentCommandRepository;

    public UpdateStudentCommandHandler(ZaminServices zaminServices,
                                    IStudentCommandRepository studentCommandRepository) : base(zaminServices)
    {
        _studentCommandRepository = studentCommandRepository;
    }

    public override async Task<CommandResult> Handle(UpdateStudentCommand command)
    {
        var studnet = await _studentCommandRepository.GetAsync(command.Id);

        if (studnet is null)
            throw new InvalidEntityStateException("کربر یافت نشد");

        studnet.Update(command.SSN, command.FirstName, command.LastName);

        try
        {
            await _studentCommandRepository.CommitAsync();

        }catch(Exception e)
        {
            Console.WriteLine(e);
            throw new InvalidEntityStateException("کد ملی تکراری !!!");   
        };

        return Ok();
    }
}
