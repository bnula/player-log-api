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
    public class Quest
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("reward")]
        public string Reward { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
        public Location StartingLocation { get; set; }
        [Column("starting_location_id")]
        public int StartingLocationId { get; set; }
        public Npc QuestGiver { get; set; }
        [Column("quest_giver_npc_id")]
        public int QuestGiverId { get; set; }
        public Campaign Campaign { get; set; }
        [Column("campaign_id")]
        public int CampaignId { get; set; }
    }
}