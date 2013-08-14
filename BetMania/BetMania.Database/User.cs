using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetMania.Database
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AvatarUrl { get; set; }
        public decimal Balance { get; set; }

        // Navigation Properties
        public int RoleId { get; set; }
        public virtual UserRole Role { get; set; }
    }
}
