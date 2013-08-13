using BetMania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetMania.Services.Models
{
    public class BetMatchModel
    {
        public int Id { get; set; }
        public decimal MakeBet { get; set; }
        public MatchModel Match { get; set; }
    }
}