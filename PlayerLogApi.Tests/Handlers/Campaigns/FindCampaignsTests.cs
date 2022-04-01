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
    public class FindCampaignsTests : InMemoryDbTest<PlayerLogDbContext>
    {
        private FindCampaignsQueryHandler CreateHandler(PlayerLogDbContext context)
        {
            var handler = new FindCampaignsQueryHandler(context);
            return handler;
        }

        private List<Campaign> CreateMockData()
        {
            var data = new List<Campaign>
            {
                new Campaign
                {
                    Id = 1,
                    Name = "eric"
                },
                new Campaign
                {
                    Id = 2,
                    Name = "jimmy"
                },
                new Campaign
                {
                    Id = 3, Name = "timmy"
                }
            };
            return data;
        }

        [Fact(DisplayName = "Finding campaigns, returns a list of campaigns")]
        public async Task FindCampaigns_Return_ListOfCampaigns()
        {
            using var context = new PlayerLogDbContext(DbContextOptions);
            var campaigns = CreateMockData();

            context.Campaigns.AddRange(campaigns);
            await context.SaveChangesAsync();

            var handler = CreateHandler(context);
            var result = await handler.Handle(new FindCampaignsQueryRequest(), CancellationToken.None);

            Assert.True(result.Data.Count() == 3);
            Assert.True(result.TotalCount == 3);
        }

        [Fact(DisplayName = "Finding campaigns, if there are none, return empty list")]
        public async Task FindCampaigns_Returns_EmptyList()
        {
            using var context = new PlayerLogDbContext(DbContextOptions);

            var handler = CreateHandler(context);
            var result = await handler.Handle(new FindCampaignsQueryRequest(), CancellationToken.None);

            Assert.True(!result.Data.Any());
            Assert.True(result.TotalCount == 0);
        }
    }
}
