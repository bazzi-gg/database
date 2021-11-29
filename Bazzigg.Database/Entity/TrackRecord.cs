using System;
using System.Collections.Generic;

namespace Bazzigg.Database.Entity
{
    public class TrackRecord
    {
        public string TrackId { get; set; }
        public string Channel { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<double> Records { get; set; }
    }
}
