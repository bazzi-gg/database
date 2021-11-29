using System;

namespace Bazzigg.Database.Model.Match
{
    public class RecentTrackSummary
    {
        public string Track { get; set; }
        public string TrackHash { get; set; }
        public int Lose { get; set; }
        public int Win { get; set; }
        public double WinningRate { get; set; }
        public int TrackPlayCount { get; set; }
        public TimeSpan BestTime { get; set; }
        public double Top { get; set; }
    }

}
