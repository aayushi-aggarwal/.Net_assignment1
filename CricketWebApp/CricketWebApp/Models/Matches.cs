using System;
using System.Collections.Generic;

namespace CricketWebApp.Models
{
    public partial class Matches
    {
        public int MatchId { get; set; }
        public int? StadiumId { get; set; }
        public int? TeamA { get; set; }
        public int? TeamB { get; set; }
        public int? Result { get; set; }
        public DateTime? DateTime { get; set; }
        public int? WasMatchPlayed { get; set; }

        public Stadium Stadium { get; set; }
        public Country TeamANavigation { get; set; }
        public Country TeamBNavigation { get; set; }
    }
}
