using Microsoft.EntityFrameworkCore;
using PlayerLogApi.Data.Db;
using PlayerLogApi.Data.Db.Entities;
using PlayerLogApi.Data.Models;
using PlayerLogApi.Handlers.Campaigns.Command;
using PlayerLogApi.Utils.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PlayerLogApi.Tests.Handlers.Campaigns
{
    public class UpdateCampaignTests : InMemoryDbTest<PlayerLogDbContext>
    {
        private UpdateCampaignCommandHandler CreateHandler(PlayerLogDbContext context)
        {
            var handler = new UpdateCampaignCommandHandler(context);
            return handler;
        }

        private List<Data.Db.Entities.Campaign> CreateMockData()
        {
            return new List<Data.Db.Entities.Campaign>
            {
                new Data.Db.Entities.Campaign
                {
                    CampaignId = 1,
                    CampaignName = "eric"
                },
                new Data.Db.Entities.Campaign
                {
                    CampaignId = 2,
                    CampaignName = "jimmy"
                }
            };
        }

        [Fact(DisplayName = "Update a campaign and return updated campaign")]
        public async Task UpdateCampaign_Returns_UpdatedCampaign()
        {
            using var context = new PlayerLogDbContext(DbContextOptions);
            var campaigns = CreateMockData();
            context.Add(campaigns[0]);
            await context.SaveChangesAsync();

            var handler = CreateHandler(context);
            var request = new UpdateCampaignCommandRequest 
            {
                Id = 1,
                Campaign = new CampaignUpdate
                {
                    Name = campaigns[1].CampaignName
                }
            };

            Assert.True(campaigns[0].CampaignName == await context.Campaigns.Select(c => c.CampaignName).FirstOrDefaultAsync());

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.True(campaigns[1].CampaignName == await context.Campaigns.Select(c => c.CampaignName).FirstOrDefaultAsync());
        }

    }
}
