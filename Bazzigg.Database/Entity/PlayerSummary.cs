using Kartrider.Api.Endpoints.MatchEndpoint.Models;

namespace Bazzigg.Database.Entity
{
    public class PlayerSummary
    {
        public string Nickname { get; set; }
        public License License { get; set; }
        public string CharacterHash { get; set; }

        public bool RacingMasterEmblem { get; set; }
    }
}
