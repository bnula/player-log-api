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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Campaign>()
                .HasMany(c => c.Characters)
                .WithOne(c => c.Campaign)
                .HasForeignKey(c => c.Id);

            modelBuilder.Entity<Campaign>()
                .HasData(
                new Campaign
                {
                    Id = 1,
                    Name = "eric"
                },
                new Campaign
                {
                    Id = 2,
                    Name = "jimmy"
                },
                new Campaign
                {
                    Id = 3,
                    Name = "timmy"
                });
        }
    }
}
