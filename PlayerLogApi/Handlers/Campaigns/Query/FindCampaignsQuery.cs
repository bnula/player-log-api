using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PlayerLogApi.Data.Db;
using PlayerLogApi.Data.Db.Entities;
using PlayerLogApi.Data.Mappings;
using PlayerLogApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLogApi.Handlers.Campaigns.Query
{
    public class FindCampaignsQueryRequest : IRequest<CampaignResult>
    {

    }

    public class FindCampaignsQueryHandler : IRequestHandler<FindCampaignsQueryRequest, CampaignResult>
    {
        private readonly PlayerLogDbContext _dbContext;

        public FindCampaignsQueryHandler(PlayerLogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CampaignResult> Handle(FindCampaignsQueryRequest request, CancellationToken cancellationToken)
        {
            var result = new CampaignResult();

            var camps = _dbContext.Campaigns
                .AsExpandable()
                .AsNoTracking();

            if (camps.Count() == 0)
            {
                camps = new List<Data.Db.Entities.Campaign>
                {
                    new Data.Db.Entities.Campaign
                    {
                        CampaignId = 1,
                        CampaignName = "test1"
                    },
                    new Data.Db.Entities.Campaign
                    {
                        CampaignId = 2,
                        CampaignName = "trololo2"
                    }
                }.AsQueryable();

                result.TotalCount = camps.Count();
            } else
            {
                result.TotalCount = await camps.CountAsync();
            }

            var campModels = camps.Select(
                camp => CampaignMappings.MapFromModelToDb.Invoke(camp)
                );

            result.Data = campModels.ToList();

            return result;
        }
    }
}
