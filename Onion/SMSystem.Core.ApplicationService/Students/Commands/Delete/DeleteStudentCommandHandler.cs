using SMSystem.Core.Contracts.Students.Commands;
using SMSystem.Core.RequestResponse.Students.Commands.Delete;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.Data.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace MiniBlog.Core.ApplicationService.Blogs.Commands.Delete;

public sealed class DeleteStudnetCommandHandler(ZaminServices zaminServices,
                                IStudentCommandRepository studentCommandRepository
            /* , IUnitOfWork blogUnitOfWork*/) : CommandHandler<DeleteStudentCommand>(zaminServices)
{
    //private readonly IUnitOfWork _blogUnitOfWork = blogUnitOfWork;
    private readonly IStudentCommandRepository _studentCommandRepository = studentCommandRepository;

    public override async Task<CommandResult> Handle(DeleteStudentCommand command)
    {
        var blog = await _studentCommandRepository.GetGraphAsync(command.Id) ?? throw new InvalidEntityStateException("کاربر یافت نشد");
        
        blog.Delete();

        _studentCommandRepository.Delete(blog);

        await _studentCommandRepository.CommitAsync();

        return Ok();
    }
}
