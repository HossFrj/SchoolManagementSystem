using FluentValidation;
using SMSystem.Core.RequestResponse.Students.Commands.Create;
using Zamin.Extensions.Translations.Abstractions;

namespace MiniBlog.Core.RequestResponse.Blogs.Commands.Create
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateBlogCommandValidator(ITranslator translator)
        {
            RuleFor(c => c.FirstName)
                .NotNull().WithMessage(translator["Required", "FirstName"])
                .MinimumLength(3).WithMessage(translator["MinimumLength", "FirstName", "3"])
                .MaximumLength(30).WithMessage(translator["MaximumLength", "FirstName", "30"]);

            RuleFor(c => c.LastName)
                .NotNull().WithMessage(translator["Required", "LastName"]).WithErrorCode("1")
                .MinimumLength(3).WithMessage(translator["MinimumLength", "LastName", "3"]).WithErrorCode("2")
                .MaximumLength(30).WithMessage(translator["MaximumLength", "LastName", "30"]).WithErrorCode("3");
            RuleFor(c => c.SSN)
                .NotNull().WithMessage(translator["Required", "SSN"])
                .MinimumLength(9).WithMessage(translator["MinimumLength", "SSN", "9"])
                .MaximumLength(10).WithMessage(translator["MaximumLength", "SSN", "10"]);
        }
    }
}
