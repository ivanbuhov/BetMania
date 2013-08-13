using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BetMania.Models;

namespace BetMania.Database
{
    public class BetManiaContext : DbContext
    {
        public BetManiaContext()
            : base("BetManiaDb") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Match> Matchs { get; set; }
        public DbSet<MatchCategory> MatchCategories { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<BetType> BetTypes { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
