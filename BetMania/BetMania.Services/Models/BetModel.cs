using BetMania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetMania.Services.Models
{
    public class BetModel
    {
        public int Id { get; set; }
        public decimal MakeBet { get; set; }

        // Navigation Properties
        public virtual User User { get; set; }
        public virtual Match Match { get; set; }
        public virtual BetType BetType { get; set; }
    }
}