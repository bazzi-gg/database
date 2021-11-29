

using Bazzigg.Database.Context;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bazzigg.Database.Test
{
    [TestClass]
    public class DBTests
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            new AppDbContext(TestOptions.AppDbContextOptions).Database.EnsureDeleted();

        }
        [TestMethod("单捞磐海捞胶 积己")]
        public void CreateAppDB()
        {
            new AppDbContext(TestOptions.AppDbContextOptions).Database.EnsureCreated();
        }
    }
}
