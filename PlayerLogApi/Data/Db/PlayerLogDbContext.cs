using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLogApi.Data.Db
{
    public class PlayerLogDbContext : DbContext
    {
        private IConfiguration _config;

        public PlayerLogDbContext(IConfiguration config)
        {
            _config = config;
        }

    }
}
