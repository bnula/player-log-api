using LinqKit;
using MediatR;
using PlayerLogApi.Data.Db;
using PlayerLogApi.Data.Db.Entities;
using PlayerLogApi.Data.Mappings;
using PlayerLogApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLogApi.Handlers.Campaigns.Query
{
    public class FindCampaignsQueryRequest : IRequest<CampaignsResult>
    {

    }

    public class FindCampaignsQueryHandler : IRequestHandler<FindCampaignsQueryRequest, CampaignsResult>
    {
        private readonly PlayerLogDbContext _dbContext;

        public FindCampaignsQueryHandler(PlayerLogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CampaignsResult> Handle(FindCampaignsQueryRequest request, CancellationToken cancellationToken)
        {
            var result = new CampaignsResult();

            var camps = _dbContext.Campaigns
                .AsExpandable()
                .AsNoTracking();

            result.TotalCount = await camps.CountAsync();

            var campModels = camps.Select(
                camp => CampaignMappings.MapFromModelToDb.Invoke(camp)
                );

            result.Data = await campModels.ToListAsync();

            return result;
        }
    }
}
