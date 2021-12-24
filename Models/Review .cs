using EX3.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EX3.Models
{
    public class Review
    {
        int revId;
        string artId;
        string revName;
        string revEmail;
        DateTime revDate;
        int rate;
        string revText;

        public Review(string artId, string revName, string revEmail, DateTime revDate, int rate, string revText)
        {
            this.artId = artId;
            this.revName = revName;
            this.revEmail = revEmail;
            this.revDate = revDate;
            this.rate = rate;
            this.revText = revText;
        }

        public Review()
        {

        }
        public string ArtId { get => artId; set => artId = value; }
        public string RevName { get => revName; set => revName = value; }
        public string RevEmail { get => revEmail; set => revEmail = value; }
        public DateTime RevDate { get => revDate; set => revDate = value; }
        public int Rate { get => rate; set => rate = value; }
        public string RevText { get => revText; set => revText = value; }
        public int RevId { get => revId; set => revId = value; }

        public int Insert()
        {
            DataServices ds = new DataServices();
            this.revName = this.revName.Replace("'", "''");
            this.revText = this.revText.Replace("'", "''");
            int status = ds.InsertRev(this);
            return status;
        }

        public List<Review> getAllRev()
        {
            DataServices dbs = new DataServices();
            return dbs.ReadRev();
        }
    }
}