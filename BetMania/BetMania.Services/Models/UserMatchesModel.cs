using BetMania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetMania.Services.Models
{
    public class UserMatchesModel
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public IEnumerable<Match> Matches { get; set; }
    }
}