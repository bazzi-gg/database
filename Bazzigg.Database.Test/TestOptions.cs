
using Bazzigg.Database.Context;

using Kartrider.Api;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Bazzigg.Database.Test
{
    [TestClass]
    public class TestOptions
    {
        public static KartriderApi KartriderApi { get; private set; }
        public static DbContextOptions<AppDbContext> AppDbContextOptions { get; private set; }
        [AssemblyInitialize]
        public static void Init(TestContext context)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables("TEST_")
                .Build();
            string appDbConnectionString = configuration["APP_DB_CONNECTION_STRING"];
            AppDbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseMySql(appDbConnectionString, ServerVersion.Parse("10.5.6-MariaDB", ServerType.MariaDb), options =>
                {

                })
                 .EnableSensitiveDataLogging() // <-- These two calls are optional but help
                .EnableDetailedErrors()       // <-- with debugging (remove for production).
                .Options;
            KartriderApi = KartriderApi.GetInstance(configuration["NEXON_OPEN_API_KEY"]);
        }
    }
}
