using BetMania.Models;
using BetMania.Repositories;
using BetMania.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BetMania.Services.Controllers
{
    public class BetController : ApiController
    {
        private IRepository<Bet> betRepository;

        public BetController(IRepository<Bet> betRep)
        {
            this.betRepository = betRep;
        }

        // GET api/bet
        public IEnumerable<BetModel> Get()
        {
            var bets = this.betRepository.All();

            var betModel = from betEntity in bets
                            select new BetModel
                            {
                                 Id = betEntity.Id,
                                 MakeBet = betEntity.MakeBet,
                                 BetType = betEntity.BetType,
                                 Match = betEntity.Match,
                                 User = betEntity.User
                            };
            return betModel;
        }

        // GET api/bet/5
        public Bet Get(int id)
        {
            return this.betRepository.Get(id);
        }

        // POST api/bet
        public Bet Post(Bet value)
        {
            return this.betRepository.Add(value);
        }

        // PUT api/bet/5
        public void Put(int id, Bet value)
        {
            if (ModelState.IsValid)
            {
                if (value.Id != id)
                {
                    throw new ArgumentException("Not user with such id");
                }

                this.betRepository.Update(value);
            }
        }

        // DELETE api/bet/5
        public void Delete(int id)
        {   
            this.betRepository.Delete(id);
        }
    }
}
