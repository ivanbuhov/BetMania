using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetMania.Models
{
    public class MatchCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Match> Matchs { get; set; }

        public MatchCategory()
        {
            this.Matchs = new HashSet<Match>();
        }
    }
}
