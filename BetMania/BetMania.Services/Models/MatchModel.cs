﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetMania.Services.Models
{
    public class MatchModel
    {
        public int Id { get; set; }
        public string Home { get; set; }
        public string Away { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public double? HomeCoefficient { get; set; }
        public double? AwayCoefficient { get; set; }
        public double? DrawCoefficient { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsFinished { get; set; }
    }
}