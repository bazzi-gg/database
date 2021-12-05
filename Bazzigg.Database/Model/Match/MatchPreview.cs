using System;

namespace Bazzigg.Database.Model.Match
{
    public class MatchPreview
    {
        public string MatchId { get; set; }
        public bool Win { get; set; }
        public DateTime EndDateTime { get; set; }
        public int Rank { get; set; }
        public string Track { get; set; }
        public string Kartbody { get; set; }
        public string KartbodyHash { get; set; }
        public string Character { get; set; }
        public string CharacterHash { get; set; }
        public TimeSpan Record { get; set; }
        public string Channel { get; set; }

    }
}
