using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionary.Models;
using Dictionary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dictionary.API
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        //private readonly ILogger<UserController> _logger;
        // private readonly DictionaryContext _db;
        private readonly AppUserRepository _user;

        public UserController
            (
            //ILogger<UserController> logger,
            // DictionaryContext db,
            AppUserRepository user)
        {
            //_logger = logger;
            // _db = db;
            _user = user;
        }


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        //public string Get(AppUser user)
        //{
            
        //}

        // POST api/<controller>
        [HttpPost]
        public string Post(AppUser user)
        {
            Log.log("api/User/Post starts...");
            if (_user.FindUser(user))
            {
                // save data to Session
                HttpContext.Session.SetString("username", user.UserName);

                return "ok";
            }
            return "false";
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
