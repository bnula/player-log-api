using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace PlayerLogApi.Data.Db.Entities
{
    public class Campaign
    {
        [Key]
        [Column("id")]
        public int CampaignId { get; set; }
        [Column("campaign_name")]
        public string CampaignName { get; set; }
    }
}
