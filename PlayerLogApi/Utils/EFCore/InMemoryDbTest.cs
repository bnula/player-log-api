using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace PlayerLogApi.Utils.EFCore
{
    public abstract class InMemoryDbTest<T>
        where T : DbContext
    {
        protected DbContextOptions<T> DbContextOptions { get; }

        protected InMemoryDbTest()
        {
            var servicePorivder = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            DbContextOptions = new DbContextOptionsBuilder<T>()
                .UseInMemoryDatabase(databaseName: "testDb")
                .UseInternalServiceProvider(servicePorivder)
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
        }
    }
}
