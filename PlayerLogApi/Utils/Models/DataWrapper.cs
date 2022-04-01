using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace PlayerLogApi.Utils.Models
{
    public class DataWrapper<T>
    {
        public IEnumerable<T> Data { get; set; }
    }
}
