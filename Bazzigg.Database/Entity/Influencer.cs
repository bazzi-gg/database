using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzigg.Database.Entity
{
    public class Influencer
    {
        public string AccessId { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
        public List<string> Keywords { get; set; }
        public string YoutubeLink { get; set; }
        public string TwitchLink { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
