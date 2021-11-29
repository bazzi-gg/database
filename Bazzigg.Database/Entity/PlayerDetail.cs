using Bazzigg.Database.Model.Match;

using Kartrider.Api.Endpoints.MatchEndpoint.Models;

using System;
using System.Collections.Generic;

namespace Bazzigg.Database.Entity
{
    public class PlayerDetail
    {
        public string AccessId { get; set; }
        public bool RacingMasterEmblem { get; set; }
        public string Channel { get; set; }
        public string Character { get; set; }
        public License License { get; set; }
        public DateTime LastRenewal { get; set; }
        public string Nickname { get; set; }
        public List<RecentTrackSummary> RecentTrackRecords { get; set; }
        public RecentMatchSummary RecentMatchSummary { get; set; }
        public List<MatchPreview> Matches { get; set; }
    }
}
