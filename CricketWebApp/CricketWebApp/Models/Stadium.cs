using System;
using System.Collections.Generic;

namespace CricketWebApp.Models
{
    public partial class Stadium
    {
        public Stadium()
        {
            Matches = new HashSet<Matches>();
        }

        public int StadiumId { get; set; }
        public long? StadiumCount { get; set; }
        public string StadiumName { get; set; }
        public int? NoOfMatchesAllowed { get; set; }

        public ICollection<Matches> Matches { get; set; }
    }
}
