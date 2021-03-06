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
    public class Location
    {
        [Key]
        [Column("id")]
        public int LocationId { get; set; }
        [Column("location_name")]
        public string LocationName { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
        [Column("location_type")]
        public string LocationType { get; set; }
        [Column("location_inventory")]
        public string LocationInventory { get; set; }
        public Campaign Campaign { get; set; }
        [Column("campaign_id")]
        public int CampaignId { get; set; }
    }
}
