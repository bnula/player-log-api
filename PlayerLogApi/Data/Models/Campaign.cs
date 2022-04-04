using PlayerLogApi.Data.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace PlayerLogApi.Data.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Location> Locations { get; set; }
    }
}
