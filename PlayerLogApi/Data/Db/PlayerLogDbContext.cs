using Microsoft.EntityFrameworkCore;
using PlayerLogApi.Data.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace PlayerLogApi.Data.Db
{
    public class PlayerLogDbContext : DbContext
    {
        public PlayerLogDbContext(DbContextOptions<PlayerLogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Army> Armies { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Npc> Npcs { get; set; }
        public DbSet<Quest> Quests { get; set; }
    }
}
