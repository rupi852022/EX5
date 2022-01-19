using EX3.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EX3.Models
{
    public class Article
    {
        string serid;
        string sName;
        string artId;
        string heder;
        string summery;
        string sorce;
        DateTime pdate;
        string picUrl;
        string link;

        public Article(string serid, string sName, string artId, string heder, string summery, string sorce, DateTime pdate, string picUrl, string link)
        {
            this.serid = serid;
            this.sName = sName;
            this.artId = artId;
            this.heder = heder;
            this.summery = summery;
            this.sorce = sorce;
            this.pdate = pdate;
            this.picUrl = picUrl;
            this.link = link;
        }

        public Article() { }

        public string Serid { get => serid; set => serid = value; }
        public string SName { get => sName; set => sName = value; }
        public string ArtId { get => artId; set => artId = value; }
        public string Heder { get => heder; set => heder = value; }
        public string Summery { get => summery; set => summery = value; }
        public string Sorce { get => sorce; set => sorce = value; }
        public DateTime Pdate { get => pdate; set => pdate = value; }
        public string PicUrl { get => picUrl; set => picUrl = value; }
        public string Link { get => link; set => link = value; }


        public int Insert(int UserId)
        {
            DataServices ds = new DataServices();
            this.heder= this.Heder.Replace("'", "''");
            this.summery = this.summery.Replace("'", "''");
            int status = ds.InsertArt(this, UserId);
            return status;
        }
        public List<string> getAllTv(int userId)
        {
            DataServices dbs = new DataServices();
            return dbs.ReadTVsName(userId);

        }

        public List<Article> getAllArt(string srName, int userId)
        {
            DataServices dbs = new DataServices();
            return dbs.ReadArticals(srName, userId);
        }

        public int updateStatus(string Artid, int UserId)
        {
            DataServices ds = new DataServices();
            int status = ds.updateAllArt(Artid, UserId);
            return status;
        }



    }
}