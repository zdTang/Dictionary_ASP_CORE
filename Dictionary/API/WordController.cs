using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionary.Models;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dictionary.API
{
    [Route("api/[controller]")]
    public class WordController : Controller
    {
        private readonly DictionaryContext _db;
        private readonly JavaScriptSerializer _serializer;
        public WordController(DictionaryContext db, JavaScriptSerializer se)
        {
            _db = db;
            _serializer = se;
        }
        
        
        
        //GET: api/<controller>
        [HttpGet]
        //public IEnumerable<string> Get(string i)
        public string Get(string i)
        {
            Log.log("api/Word/Get starts...");

            List<EnWords> wordList = _db.EnWords.Where(u => u.Word.StartsWith(i)).Take(5).ToList();
            //List<EnWords> list;
            //if (wordList.Count()>5)  // only give the first 5 words
            //{
            //    list = wordList.Take(5).ToList();
            //}
            //else
            //{
            //    list = wordList.Take(wordList.Count()).ToList();
            //}

            string x=_serializer.Serialize(wordList);
            // Get a list of words
            //return new string[] { wordList.Count().ToString(), "value2" };
            return x;
        }
        /// <summary>
        /// this api returns result to the browser
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public int Get(int i)
        {
            Log.log("api/Word/Get{id} starts...");



            return i;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
