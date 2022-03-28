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
    public class Army
    {
        [Key]
        [Column("id")]
        public int ArmyId { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
        [Column("composition")]
        public string ArmyComposition { get; set; }
        public Campaign Campaign { get; set; }
        [Column("campaign_id")]
        public int CampaignId { get; set; }
        public Location HomeLocation { get; set; }
        [Column("home_location_id")]
        public int HomeLocationId { get; set; }
        public Location CurrentLocation { get; set; }
        [Column("current_location_id")]
        public int CurrentLocationId { get; set; }
        public Npc Leader { get; set; }
        [Column("leader_id")]
        public int LeaderId { get; set; }
    }
}
