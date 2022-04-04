using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLogApi.Data.Mappings
{
    public static class LocationMappings
    {
        public static readonly Expression<Func<Db.Entities.Location, Models.Location>> MapFromDbToModel =
            location => new Models.Location
            {
                Id = location.Id,
                Name = location.Name,
                Campaign = new Models.Campaign { Id = location.CampaignId },
                Description = location.Description,
                LocationInventory = location.LocationInventory,
                LocationType = location.LocationType,
                Notes = location.Notes
            };
    }
}
