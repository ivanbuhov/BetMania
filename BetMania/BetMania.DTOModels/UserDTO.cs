using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetMania.DTOModels
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string AvatarUrl { get; set; }
        public decimal Balance { get; set; }
        public string Role { get; set; }
    }
}
