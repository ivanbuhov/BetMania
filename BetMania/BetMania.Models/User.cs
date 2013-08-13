using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetMania.Models
{
    public class User
    {
        public IEnumerable<Match> matches;

        public User()
        {
            this.matches = new HashSet<Match>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Avatatr { get; set; }
        public decimal? Balance { get; set; }

        public virtual UserRole UserRole { get; set; } 

    }
}
