﻿using LinqKit;
using MediatR;
using PlayerLogApi.Data.Db;
using PlayerLogApi.Data.Db.Entities;
using PlayerLogApi.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLogApi.Handlers.Campaigns.Query
{
    public class GetCampaignQueryRequest : IRequest<Data.Models.Campaign>
    {
        public int Id { get; set; }
    }

    public class GetCampaignQueryHandler : IRequestHandler<GetCampaignQueryRequest, Data.Models.Campaign>
    {
        private readonly PlayerLogDbContext _dbContext;

        public GetCampaignQueryHandler(PlayerLogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Data.Models.Campaign> Handle(GetCampaignQueryRequest request, CancellationToken cancellationToken)
        {
            var camp = await _dbContext.Campaigns
                .AsExpandable()
                .AsNoTracking()
                .Where(c => c.Id == request.Id)
                .Select(camp => CampaignMappings.MapFromDbToModel.Invoke(camp))
                .SingleOrDefaultAsync();

            camp = await AddLocations(camp);

            return camp;
        }

        private async Task<Data.Models.Campaign> AddLocations(Data.Models.Campaign campaign)
        {
            var locations = _dbContext.Locations
                .AsExpandable().AsNoTracking()
                .Where(loc => loc.CampaignId == campaign.Id);
            campaign.Locations = await locations.Select(loc => LocationMappings.MapFromDbToModel.Invoke(loc)).ToListAsync();
            return campaign;
        }
    }
}
