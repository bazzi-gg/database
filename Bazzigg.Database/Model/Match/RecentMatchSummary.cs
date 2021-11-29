namespace Bazzigg.Database.Model.Match
{
    public class RecentMatchSummary
    {

        public const int RECENT_MATCH_SUMMARY_COUNT = 30;
        public double WinRate { get; set; }
        public int Win { get; set; }
        public int Lose { get; set; }
        public double AverageRank { get; set; }
        public string MostPlayedTrack { get; set; }
        public string MostUsedKartbody { get; set; }
    }
}
