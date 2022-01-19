using EX3.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EX3.Models
{
    public class User
    {
        int id;
        string fName;
        string lName;
        DateTime birthDate;
        string email;
        string password;

        public User(string fName, string lName, DateTime birthDate, string email, string password, int id)
        {
            this.fName = fName;
            this.lName = lName;
            if (birthDate!=null)
            {
                this.birthDate = birthDate;
            }
            this.email = email;
            this.password = password;
            this.id = id;
        }

        public User() { }

        public string FName { get => fName; set => fName = value; }
        public string LName { get => lName; set => lName = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public int Id { get => id; set => id = value; }

        public int Insert()
        {
            DataServices ds = new DataServices();
            int status = ds.InsertUser(this);
            return status;
        }

        public User readUser(string email, string password)
        {
            DataServices ds = new DataServices();
           return ds.ReadUser(email, password);
        }

    }
}