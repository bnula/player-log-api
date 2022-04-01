using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace PlayerLogApi.Data.Models
{
    public class Location
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }
        
        public string LocationType { get; set; }
        
        public string LocationInventory { get; set; }

        public Campaign Campaign { get; set; }
    }
}
