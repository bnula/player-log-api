using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLogApi.Data.Mappings
{
    public static class CampaignMappings
    {
        public static readonly Expression<Func<Db.Entities.Campaign, Models.Campaign>> MapFromModelToDb =
            campaign => new Models.Campaign
            {
                CampaignId = campaign.CampaignId,
                CampaignName = campaign.CampaignName,
            };
    }
}
