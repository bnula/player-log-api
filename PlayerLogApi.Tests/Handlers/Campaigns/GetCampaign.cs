using PlayerLogApi.Data.Db;
using PlayerLogApi.Data.Db.Entities;
using PlayerLogApi.Handlers.Campaigns.Query;
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
    public class GetCampaign : InMemoryDbTest<PlayerLogDbContext>
    {
        private GetCampaignQueryHandler CreateHandler(PlayerLogDbContext context)
        {
            var handler = new GetCampaignQueryHandler(context);
            return handler;
        }

        private Campaign CreateMockData()
        {
            return new Campaign
            {
                CampaignId = 1,
                CampaignName = "test"
            };
        }

        [Fact(DisplayName = "Getting a campaign record, return campaign")]
        public async Task GetCampaign_Returns_Campaign()
        {
            using var context = new PlayerLogDbContext(DbContextOptions);
            var campaign = CreateMockData();

            context.Campaigns.Add(campaign);
            await context.SaveChangesAsync();

            var handler = CreateHandler(context);
            var result = await handler.Handle(new GetCampaignQueryRequest { Id = 1 }, CancellationToken.None);

            Assert.NotNull(result);
            Assert.True(result.CampaignName == campaign.CampaignName);
        }

        [Fact(DisplayName = "Getting a campaign record that doesn't exist, return empty result")]
        public async Task GetCampaign_Returns_EmptyResult()
        {
            using var context = new PlayerLogDbContext(DbContextOptions);

            var handler = CreateHandler(context);
            var result = await handler.Handle(new GetCampaignQueryRequest { Id = 1 }, CancellationToken.None);

            Assert.Null(result);
        }
    }
}
