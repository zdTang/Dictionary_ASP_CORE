using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dictionary.Models;
using Dictionary.Repositories;
using Microsoft.AspNetCore.Http;

namespace Dictionary.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
       private readonly DictionaryContext _db;
        private readonly AppUserRepository _user;

        public HomeController
            (
            //ILogger<HomeController> logger ,
            DictionaryContext db,
            AppUserRepository user)
        {
            //_logger = logger;
             _db = db;
            Log.log("HomeController starts...");
            _user = user;
        }
        /// <summary>
        /// The Logon view for user to input name and password
        /// </summary>
        /// <returns></returns>
        public IActionResult index()
        {
            //_logger.LogInformation("-------------\r\nIn the Index\r\n--------------");
            Log.log("Home/Index starts...");
            return View();
        }
        /// <summary>
        /// This action could be replaced by a web API
        /// A Web Api is lightweight and can return only data
        /// While a Action can return both view and data
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        //public ContentResult Varify(AppUser user)
        //{
        //    if(_user.FindUser(user))
        //    {
        //        // save data to Session
        //        HttpContext.Session.SetString("username", user.UserName);

        //        return Content("ok");
        //    }
        //    return Content("false");
        //}

        

        /// This will display a view waiting for user'input
        public IActionResult Init()
        {
            Log.log("Home/Init starts...");
            //AppUserDto _user = user.ToDto(); 
            // Pass user's information to the VIEW
            //_logger.LogInformation("In the Init");
            string user = HttpContext.Session.GetString("username");
            ViewBag.userName = user; // pass user name to the view
            return View();
        }
        /// <summary>
        /// This action takes a word from the user
        /// </summary>
        /// <returns></returns>
        
        
        public IActionResult Search(string word)
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
