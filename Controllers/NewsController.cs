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
        public List<string> Get(int userId)
        {
            Article DBart = new Article();
            return DBart.getAllTv(userId);
        }

        // GET api/<controller>/5
        public List<Article> Get(string srName, int userId)
        {
            Article DBart = new Article();
            List<Article> serArt = DBart.getAllArt(srName, userId);
            return serArt;
        }

     

        // POST api/<controller>
        public int Post([FromBody] Article A, int UserId)
        {
            int id = A.Insert(UserId);
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