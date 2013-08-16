using BetMania.Models;
using BetMania.Notifier;
using BetMania.Repositories;
using BetMania.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BetMania.Services.Controllers
{
    public class BetsController : ApiController
    {
        private IRepository<Bet> betRepository;

        public BetsController(IRepository<Bet> betRep)
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
        public BetModel Get(int id)
        {
            var bet = this.betRepository.Get(id);

            var betModel =  new BetModel
                            {
                                 Id = bet.Id,
                                 MakeBet = bet.MakeBet,
                                 BetType = bet.BetType,
                                 Match = bet.Match,
                                 User = bet.User
                            };
            return betModel;
        }

        // POST api/bet
        public Bet Post(Bet value)
        {
            string jsonValue = JsonConvert.SerializeObject(value);
            Notifications.Publish(jsonValue);

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

                string jsonValue = JsonConvert.SerializeObject(value);
                Notifications.Publish(jsonValue);

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
