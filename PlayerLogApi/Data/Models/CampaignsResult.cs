using PlayerLogApi.Data.Db.Entities;
using PlayerLogApi.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace PlayerLogApi.Data.Models
{
    public class CampaignsResult : DataWrapper<Campaign>
    {
        public int TotalCount { get; set; }
    }
}
