using MediatR;
using Microsoft.EntityFrameworkCore;
using PlayerLogApi.Data.Db;
using PlayerLogApi.Data.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace PlayerLogApi.Handlers.Campaigns.Command
{
    public class CreateCampaignCommandRequest : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommandRequest, int>
    {
        private readonly PlayerLogDbContext _dbContext;

        public CreateCampaignCommandHandler(PlayerLogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateCampaignCommandRequest request, CancellationToken cancellationToken)
        {
            var id = await _dbContext.Campaigns.CountAsync();
            id++;

            var campaign = new Campaign
            {
                CampaignId = id,
                CampaignName = request.Name
            };

            await _dbContext.Campaigns.AddAsync(campaign);
            await _dbContext.SaveChangesAsync();

            return campaign.CampaignId;
        }
    }
}
