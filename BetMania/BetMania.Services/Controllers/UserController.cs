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
    public class UserController : ApiController
    {
        private IRepository<User> userRepository;
        // GET api/user

        public UserController(IRepository<User> userRep)
        {
            this.userRepository = userRep;
        }

        public IEnumerable<UserModel> Get()
        {
             var users =  this.userRepository.All();

             var userModel = from userEntity in users
                             select new UserModel
                             {
                                 Id = userEntity.Id,
                                 Username = userEntity.Username,
                                 Avatatr = userEntity.Avatatr,
                                 Balance = userEntity.Balance
                             };
            return userModel;
        }

        // GET api/user/5
        public User Get(int id)
        {
            return this.userRepository.Get(id);
        }

        // POST api/user
        public User Post(User value)
        {
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
    }
}
