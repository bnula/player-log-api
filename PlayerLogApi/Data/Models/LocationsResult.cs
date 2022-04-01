using PlayerLogApi.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLogApi.Data.Models
{
    public class LocationsResult : DataWrapper<Location>
    {
        public int TotalCount { get; set; }
    }
}
