using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.Translations.Abstractions;

namespace SMSystem.Core.RequestResponse.Students.Queries.GetAll
{
    class GetAllStudentByQueryValidator : AbstractValidator<GetAllStudentByQuery>
    {
        public GetAllStudentByQueryValidator(ITranslator translator)
        {
            RuleFor(query => query.Path)
                .NotEmpty()
                .WithMessage(translator["Required", nameof(GetAllStudentByQuery.StudentId)]);
        }
    }
}
