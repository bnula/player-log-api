using Microsoft.EntityFrameworkCore;
using PlayerLogApi.Data.Db;
using PlayerLogApi.Data.Db.Entities;
using PlayerLogApi.Handlers.Campaigns.Command;
using PlayerLogApi.Utils.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

#nullable disable
namespace PlayerLogApi.Tests.Handlers.Campaigns
{
    public class CreateCampaignTests : InMemoryDbTest<PlayerLogDbContext>
    {
        private CreateCampaignCommandHandler CreateHandler(PlayerLogDbContext context)
        {
            var handler = new CreateCampaignCommandHandler(context);
            return handler;
        }

        private List<Campaign> CreateMockData()
        {
            var data = new List<Campaign>
            {
                new Campaign
                {
                    CampaignId = 1,
                    CampaignName = "eric"
                },
                new Campaign
                {
                    CampaignId = 2,
                    CampaignName = "jimmy"
                }
            };

            return data;
        }

        [Fact(DisplayName = "Creating a new campaign, creates a new item in the db with autogenerated id")]
        public async Task CreateCampaign_Returns_CreatedCampaign()
        {
            using var context = new PlayerLogDbContext(DbContextOptions);

            var campaigns = CreateMockData();
            context.AddRange(campaigns);
            await context.SaveChangesAsync();

            var handler = CreateHandler(context);
            var result = await handler.Handle(new CreateCampaignCommandRequest { Name = "timmy" }, CancellationToken.None);
            var resultDbCamp = await context.Campaigns.FirstOrDefaultAsync(c => c.CampaignName == "timmy");
            
            Assert.NotNull(resultDbCamp);
            Assert.True(resultDbCamp.CampaignId == 3);
        }
    }
}
