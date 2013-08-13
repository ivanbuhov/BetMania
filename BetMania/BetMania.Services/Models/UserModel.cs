using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetMania.Services.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Avatatr { get; set; }
        public decimal? Balance { get; set; }
    }
}