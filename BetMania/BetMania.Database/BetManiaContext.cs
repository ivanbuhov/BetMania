using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BetMania.Database
{
    public class BetManiaContext : DbContext
    {
        public BetManiaContext()
            : base("BetManiaDb") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Match> Users { get; set; }
        public DbSet<MatchCategory> Users { get; set; }
        public DbSet<Bet> Users { get; set; }
        public DbSet<BetType> Users { get; set; }
        public DbSet<UserRole> Users { get; set; }
    }
}
