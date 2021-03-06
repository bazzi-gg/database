

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
        [TestMethod("데이터베이스 생성")]
        public void CreateAppDB()
        {
            new AppDbContext(TestOptions.AppDbContextOptions).Database.EnsureCreated();
        }
    }
}
