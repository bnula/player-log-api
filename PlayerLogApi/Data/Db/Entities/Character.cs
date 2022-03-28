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
    public class Character
    {
        [Key]
        [Column("id")]
        public int CharacterId { get; set; }
        [Column("character_name")]
        public string CharacterName { get; set; }
        [Column("level")]
        public int Level { get; set; }
        public Campaign Campaign { get; set; }
        [Column("character_id")]
        public int CampaignId { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
    }
}
