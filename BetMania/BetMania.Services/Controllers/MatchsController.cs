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
    public class MatchsController : ApiController
    {
        private IRepository<Match> matchReposit;

        public MatchsController(IRepository<Match> matchRep)
        {
            this.matchReposit = matchRep;
        }


        // GET api/matchs
        public IEnumerable<MatchModel> Get()
        {
            var matchs = this.matchReposit.All();

            var matchModels = from matchEntity in matchs
                              select new MatchModel
                              {
                                  Id = matchEntity.Id,
                                  Home = matchEntity.Home,
                                  Away = matchEntity.Away,
                                  HomeScore = matchEntity.HomeScore,
                                  AwayScore = matchEntity.AwayScore,
                                  HomeCoefficient = matchEntity.HomeCoefficient,
                                  AwayCoefficient = matchEntity.AwayCoefficient,
                                  DrawCoefficient = matchEntity.DrawCoefficient,
                                  StartTime = matchEntity.StartTime,
                                  IsFinished = matchEntity.IsFinished
                              };
            return matchModels;
           
        }

        // GET api/matchs/5
        public MatchModel Get(int id)
        {
            var match = this.matchReposit.Get(id);

            var matchModel = new MatchModel
                              {
                                  Id = match.Id,
                                  Home = match.Home,
                                  Away = match.Away,
                                  HomeScore = match.HomeScore,
                                  AwayScore = match.AwayScore,
                                  HomeCoefficient = match.HomeCoefficient,
                                  AwayCoefficient = match.AwayCoefficient,
                                  DrawCoefficient = match.DrawCoefficient,
                                  StartTime = match.StartTime,
                                  IsFinished = match.IsFinished
                              };

            return matchModel;
        }

        // POST api/matchs
        public Match Post(Match value)
        {
            string jsonValue = JsonConvert.SerializeObject(value);
            Notifications.Publish(jsonValue);

            return this.matchReposit.Add(value);
        }

        // PUT api/matchs/5
        public Match Put(int id, Match value)
        {
            string jsonValue = JsonConvert.SerializeObject(value);
            Notifications.Publish(jsonValue);

            return this.matchReposit.Update(value);
        }

        // DELETE api/matchs/5
        public void Delete(int id)
        {
            this.matchReposit.Delete(id);
        }
    }
}
