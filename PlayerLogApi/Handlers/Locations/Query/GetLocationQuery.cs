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

#nullable disable
namespace PlayerLogApi.Handlers.Locations.Query
{
    public class GetLocationQueryRequest : IRequest<Location>
    {
        public int Id { get; set; }
    }

    public class GetLocationQueryHandler : IRequestHandler<GetLocationQueryRequest, Location>
    {
        private readonly PlayerLogDbContext _dbContext;

        public GetLocationQueryHandler(PlayerLogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Location> Handle(GetLocationQueryRequest request, CancellationToken cancellationToken)
        {
            var location = await _dbContext.Locations
                .AsExpandable()
                .AsNoTracking()
                .Where(l => l.Id == request.Id)
                ?.Select(loc => LocationMappings.MapFromDbToModel.Invoke(loc))
                .SingleOrDefaultAsync();

            var camp = await _dbContext.Campaigns
                .AsExpandable().AsNoTracking()
                .Where(c => c.Id == location.Campaign.Id).SingleOrDefaultAsync();

            location.Campaign = CampaignMappings.MapFromDbToModel.Invoke(camp);

            return location;
        }
    }
}
