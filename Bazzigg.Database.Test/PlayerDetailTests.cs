

using Bazzigg.Database.Context;
using Bazzigg.Database.Entity;
using Bazzigg.Database.Model.Match;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazzigg.Database.Test
{
    [TestClass]
    public class PlayerDetailTests
    {
        [TestMethod(displayName: "추가")]
        public void Add()
        {
            using var context = new AppDbContext(TestOptions.AppDbContextOptions);
            var matches = new List<MatchPreview>
            {
                new MatchPreview()
                {
                    Character = "아라비아 왕자 우니",
                    CharacterHash = "1",
                    EndDateTime = System.DateTime.MaxValue,
                    Kartbody = "골든 스톰 블레이드 X",
                    MatchId = "",
                    KartbodyHash = "",
                    Rank = 0,
                    Track = "",
                    Win = true
                }
            };
            var playerDetail = new PlayerDetail()
            {
                AccessId = "",
                Channel = "",
                Character = "",
                License = Kartrider.Api.Endpoints.MatchEndpoint.Models.License.None,
                Nickname = "",
                RacingMasterEmblem = false,
                Matches = matches,
            };
            context.PlayerDetail.Add(playerDetail);
            context.SaveChanges();
        }
    }
}
