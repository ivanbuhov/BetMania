using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetMania.Services.Models
{
    public class SingleMatchCatModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        IEnumerable<MatchModel> Matches { get; set; }
    }
}