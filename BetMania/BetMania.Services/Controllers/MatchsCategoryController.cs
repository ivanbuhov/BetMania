﻿using BetMania.Models;
using BetMania.Repositories;
using BetMania.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace BetMania.Services.Controllers
{
    public class MatchsCategoryController : ApiController
    {
        private IRepository<MatchCategory> matchRepository;

        public MatchsCategoryController(IRepository<MatchCategory> betRep)
        {
            this.matchRepository = betRep;
        }

        // GET api/category
        public IEnumerable<MatchCategoryModelAll> Get()
        {
          var matchCat = this.matchRepository.All();

          var matchCatModel = from matchCatEntity in matchCat
                              select new MatchCategoryModelAll
                              {
                                Id = matchCatEntity.Id,
                                Name = matchCatEntity.Name
                              };

        return matchCatModel;
          
        }

        // GET api/category/5
        public SingleMatchCatModel Get(int id)
        {
         //    var user = this.userRepository.All().Include(usr => usr.Bets.Select(b => b.Match));
            var matchCat  = this.matchRepository.Get(id);
            List<MatchModel> matchesInCat = new List<MatchModel>();

            foreach (var match in matchCat.Matchs)
	        {
		      matchesInCat.Add(
                    new MatchModel
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
                    }
                  );
	        };

            IList<MatchModel> newMatchCol = new List<MatchModel>();
            new SingleMatchCatModel
            {
                Id = matchCat.Id,
                Name = matchCat.Name,  
                Matches = matchesInCat
            }
            return matchCat;
        }

        // POST api/category
        public void Post(MatchCategory value)
        {
            this.matchRepository.Add(value);
        }

        // PUT api/category/5
        public void Put(int id, MatchCategory value)
        {
            if (ModelState.IsValid)
            {
                if (value.Id != id)
                {
                    throw new ArgumentException("Not match Cat with such id");
                }

                this.matchRepository.Update(value);
            }
        }

        // DELETE api/category/5
        public void Delete(int id)
        {
            this.matchRepository.Delete(id);
        }
    }
}
