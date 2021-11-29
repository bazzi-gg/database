

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
        public async Task Add()
        {
            using var context = new AppDbContext(TestOptions.AppDbContextOptions);
            var match = await TestOptions.KartriderApi.Match.GetMatchDetailAsync("03bd00105ddcdf7a");
            foreach (var player in match.Players)
            {
                var playerInfo = await TestOptions.KartriderApi.Match.GetMatchesByAccessIdAsync(player.AccessId);
                var matches = new List<MatchPreview>();
                foreach (var playerMatch in playerInfo.Matches["effd66758144a29868663aa50e85d3d95c5bc0147d7fdb9802691c2087f3416e"])
                {
                    matches.Add(new MatchPreview()
                    {
                        Character = "아라비아 왕자 우니",
                        CharacterHash = playerMatch.Player.Character,
                        EndDateTime = playerMatch.EndDateTime,
                        Kartbody = "골든 스톰 블레이드 X",
                        MatchId = playerMatch.MatchId,
                        KartbodyHash = playerMatch.Player.Kartbody,
                        Rank = playerMatch.Player.Rank,
                        Track = playerMatch.TrackId,
                        Win = playerMatch.Player.Win
                    });
                }
                var playerDetail = new PlayerDetail()
                {
                    AccessId = player.AccessId,
                    Channel = match.Channel,
                    Character = player.Character,
                    License = player.License,
                    Nickname = player.Nickname,
                    RacingMasterEmblem = false,
                    Matches = matches,
                };
                context.PlayerDetail.Add(playerDetail);
            }
            context.SaveChanges();
        }
    }
}
