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

namespace PlayerLogApi.Tests.Handlers.Campaigns
{
    public class DeleteCampaignTests : InMemoryDbTest<PlayerLogDbContext>
    {
        private DeleteCampaignCommandHandler CreateHandler(PlayerLogDbContext context)
        {
            var handler = new DeleteCampaignCommandHandler(context);
            return handler;
        }

        private List<Campaign> CreateMockData()
        {
            return new List<Campaign>
            {
                new Campaign
                {
                    CampaignId = 1,
                    CampaignName = "eric"
                },
                new Campaign
                {
                    CampaignId = 2,
                    CampaignName = "timmy"
                }
            };
        }

        [Fact(DisplayName = "Deleting Campaign, campaign is removed from db")]
        public async Task DeleteCampaign()
        {
            using var context = new PlayerLogDbContext(DbContextOptions);
            var campaigns = CreateMockData();

            context.AddRange(campaigns);
            await context.SaveChangesAsync();

            var handler = CreateHandler(context);
            await handler.Handle(new DeleteCampaignCommandRequest { Id = 2 }, CancellationToken.None);

            var camps = await context.Campaigns.ToListAsync();
            Assert.True(camps.Count() == 1);
            Assert.True(camps[0].CampaignName == "eric");
        }
    }
}
