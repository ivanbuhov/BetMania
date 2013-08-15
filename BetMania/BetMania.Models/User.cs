using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetMania.Models
{
    public class User
    {
        public virtual IEnumerable<Bet> Bets {get; set;}

        public User()
        {
            this.Bets = new HashSet<Bet>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Avatatr { get; set; }
        public decimal? Balance { get; set; }

        public virtual UserRole UserRole { get; set; } 

    }
}
