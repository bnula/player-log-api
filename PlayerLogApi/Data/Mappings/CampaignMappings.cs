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
        public static readonly Expression<Func<Db.Entities.Campaign, Models.Campaign>> MapFromDbToModel =
            campaign => new Models.Campaign
            {
                Id = campaign.Id,
                Name = campaign.Name,
            };
    }
}
