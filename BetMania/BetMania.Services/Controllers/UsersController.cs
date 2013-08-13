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
    using BetMania.AvatarUploader;

    public class UsersController : ApiController
    {
        private DbUserRepository userRepository;
        // GET api/user

        public UsersController(DbUserRepository userRep)
        {
            this.userRepository = userRep;
        }


        public IEnumerable<UserModel> Get()
        {
            var users = this.userRepository.All();

            var userModel = from userEntity in users
                            select new UserModel
                            {
                                Id = userEntity.Id,
                                Username = userEntity.Username,
                                Avatatr = userEntity.Avatar,
                                Balance = userEntity.Balance
                            };
            return userModel;
        }

        // GET api/user/5
        public UserMatchesModel Get(int id)
        {
            var user = this.userRepository.Info(id);
            List<MatchModel> colMatchModel = new List<MatchModel>();
            List<BetModel> colBetModel = new List<BetModel>();

            foreach (var bet in user.Bets)
            {
               colBetModel.Add(new BetModel 
                {
                    MakeBet = bet.MakeBet
                }
                );
               colMatchModel.Add(new MatchModel
                   {
                       Id = bet.Match.Id,
                       Home = bet.Match.Home,
                       Away = bet.Match.Away,
                       HomeScore = bet.Match.HomeScore,
                       AwayScore = bet.Match.AwayScore,
                       HomeCoefficient = bet.Match.HomeCoefficient,
                       AwayCoefficient = bet.Match.AwayCoefficient,
                       DrawCoefficient = bet.Match.DrawCoefficient,
                       StartTime = bet.Match.StartTime,
                       IsFinished = bet.Match.IsFinished
                   });
            }
          

            var userModel =  new UserMatchesModel
                            {
                                Id = user.Id,
                                Username = user.Username,
                                Avatar = user.Avatar,
                                Balance = user.Balance,
                                Matches = colMatchModel,
                                Bets = colBetModel
                            };

                    
            return userModel;
        }

        // POST api/user
        public User Post(User value)
        {
            // Upload image from the user's hard driver to the BetMania's account on Dropbox
            // and save the url of the avatar from the Dropbox account to the database
            var dropboxUrl = AvatarUploader.Upload(value.Username, value.Avatar);
            value.Avatar = dropboxUrl;

            return this.userRepository.Add(value);
        }

        // PUT api/user/5
        public void Put(int id, User value)
        {
            if (ModelState.IsValid)
            {
                if (value.Id != id)
                {
                    throw new ArgumentException("Not user with such id");
                }

                this.userRepository.Update(value);
            }
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
            this.userRepository.Delete(id);
        }


        //public void GetMatchesBets(int id)
        //{ 

        //}
    }
}
