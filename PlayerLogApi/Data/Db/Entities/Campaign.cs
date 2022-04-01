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
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public IEnumerable<Npc> Npcs { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<Quest> Quests { get; set; }
        public IEnumerable<Army> Armies { get; set; }
        public IEnumerable<Character> Characters { get; set; }
    }
}
