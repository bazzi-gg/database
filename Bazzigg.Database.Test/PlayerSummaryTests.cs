using Bazzigg.Database.Context;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bazzigg.Database.Test
{
    [TestClass]
    public class PlayerSummaryTests
    {
        [TestMethod]
        public void Add()
        {
            using var context = new AppDbContext(TestOptions.AppDbContextOptions);
            context.PlayerSummary.Add(new Entity.PlayerSummary()
            {
                CharacterHash = "",
                License = Kartrider.Api.Endpoints.MatchEndpoint.Models.License.L1,
                Nickname = "TEST",
                RacingMasterEmblem = true,
            });
            context.SaveChanges();
        }

    }
}
