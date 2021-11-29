using Bazzigg.Database.Context;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace Bazzigg.Database.Test
{
    [TestClass]
    public class TrackRecordTests
    {
        [TestMethod("트랙 레코드 추가")]
        public void Add()
        {
            using var context = new AppDbContext(TestOptions.AppDbContextOptions);
            context.TrackRecord.Add(new Entity.TrackRecord()
            {
                Channel = "speedTeamCombine",
                Records = new List<double>()
                  {
                      10.01,
                      110.0,
                  },
                TrackId = "6cc07bd9cfa9699531cf954f8fd817d5a74d889d4a996ae18d6809c501a50e18"
            });
            context.SaveChanges();
        }
    }
}
