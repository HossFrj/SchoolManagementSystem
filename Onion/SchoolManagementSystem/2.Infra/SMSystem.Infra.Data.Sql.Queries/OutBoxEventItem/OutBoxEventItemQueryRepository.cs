using Microsoft.EntityFrameworkCore;
using SMSystem.Core.RequestResponse.Students.Queries.Get;
using SMSystem.Infra.Data.Sql.Queries.Common;
using SMSystem.Core.Contracts.Students.Queries;
using Zamin.Infra.Data.Sql.Queries;
using SMSystem.Core.RequestResponse.Students.Queries.OutBoxEventItemQr;

namespace SMSystem.Infra.Data.Sql.Queries.OutBoxEvenItem
{
     public class OutBoxEventItemQueryRepository : BaseQueryRepository<SMSystemQueryDbContext>, IOutBoxEventItemQueryRepository
    {
        public OutBoxEventItemQueryRepository(SMSystemQueryDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<OutBoxEventItemQr?>> ExecuteAsync(GetOutBoxEventItemByQuery query)
            => await _dbContext.OutBoxEventItems.Select(c => (OutBoxEventItemQr?)new OutBoxEventItemQr()
            {
                OutBoxEventItemId = c.OutBoxEventItemId,
                AccuredOn = c.AccuredOn,
                AggregateName= c.AggregateName,
                EventName = c.EventName,

            }).ToListAsync();
    }
}
