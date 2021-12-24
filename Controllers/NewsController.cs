using EX3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EX3.Controllers
{
    public class NewsController : ApiController
    {
        // GET api/<controller>
        public List<string> Get()
        {
            Article DBart = new Article();
            return DBart.getAllTv();
        }

        // GET api/<controller>/5
        public List<Article> Get(string srName)
        {
            Article DBart = new Article();
            List<Article> serArt = DBart.getAllArt(srName);
            return serArt;
        }

        // POST api/<controller>
        public int Post([FromBody] Article A)
        {
            int id = A.Insert();
            return id;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}