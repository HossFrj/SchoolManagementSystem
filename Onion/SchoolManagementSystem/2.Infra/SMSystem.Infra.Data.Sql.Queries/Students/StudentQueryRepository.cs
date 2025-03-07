using Microsoft.EntityFrameworkCore;
using SMSystem.Core.RequestResponse.Students.Queries.Get;
using SMSystem.Core.RequestResponse.Students.Queries.GetAll;
using SMSystem.Infra.Data.Sql.Queries.Common;
using SMSystem.Core.Contracts.Students.Queries;
using Zamin.Infra.Data.Sql.Queries;

namespace SMSystem.Infra.Data.Sql.Queries.Students;

public class StudentQueryRepository : BaseQueryRepository<SMSystemQueryDbContext>, IStudentQueryRepository
{
    public StudentQueryRepository(SMSystemQueryDbContext dbContext) : base(dbContext)
    {
    }

public async Task<List<StudentQr?>> ExecuteAsync(GetStudentByQuery query)
    => await _dbContext.Students.Select(c => (StudentQr?)new StudentQr()
    {
        Id = c.Id,
        FirstName = c.FirstName,
        LastName = c.LastName,
        SSN = c.SSN
    }).ToListAsync();
}
