using LinqKit;
using MediatR;
using PlayerLogApi.Data.Db;
using PlayerLogApi.Data.Mappings;
using PlayerLogApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLogApi.Handlers.Locations.Query
{
    public class FindLocationsQueryRequest : IRequest<LocationsResult>
    {

    }

    public class FindLocationsQueryHandler : IRequestHandler<FindLocationsQueryRequest, LocationsResult>
    {
        private readonly PlayerLogDbContext _dbContext;

        public FindLocationsQueryHandler(PlayerLogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LocationsResult> Handle(FindLocationsQueryRequest request, CancellationToken cancellationToken)
        {
            var result = new LocationsResult();

            var locations = _dbContext.Locations
                .AsExpandable()
                .AsNoTracking();
            var campaigns = _dbContext.Campaigns
                .AsExpandable()
                .AsNoTracking();
            result.TotalCount = await locations.CountAsync();

            var locationModels = await locations
                .Select(loc => LocationMappings.MapFromDbToModel.Invoke(loc)).ToListAsync();

            // check for better wy to do this
            foreach (var loc in locationModels)
            {
                var camp = await campaigns.Where(c => c.Id == loc.Campaign.Id).FirstOrDefaultAsync();
                loc.Campaign = CampaignMappings.MapFromDbToModel.Invoke(camp);
            }

            result.Data = locationModels;

            return result;
        }
    }
}
