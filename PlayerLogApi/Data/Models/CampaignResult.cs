using PlayerLogApi.Data.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace PlayerLogApi.Data.Models
{
    public class CampaignResult
    {
        public int TotalCount { get; set; }
        public List<Campaign> Data { get; set; }
    }
}
