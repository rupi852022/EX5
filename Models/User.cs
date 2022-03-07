using EX3.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EX3.Models
{
    public class User
    {
        // OHANA
        private int id;
        private string fName;
        private string lName;
        private DateTime birthDate;
        private string email;
        private string password;

        public User() { }

        // OHANA
        public User(string email, string password, string fName, string lName, DateTime birthDate)
        {
            this.email = email;
            this.password = password;
            this.fName = fName;
            this.lName = lName;

            if (birthDate!=null)
            {
                this.birthDate = birthDate;
            }
        }

        public User(int id, string email, string password, string fName, string lName, DateTime birthDate)
        {
            this(email, password, fName, lName, birthDate)
            this.id = id;
        }

        // OHANA
        public string FName { get => fName; set => fName = value; }
        public string LName { get => lName; set => lName = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public int Id { get => id; set => id = value; }

        public int Insert()
        {
            DataServices ds = new DataServices();
            User user = ds.ReadUser(this.email);

            if (user != null) 
            {
                return -1; // USER already exist
            }

            int status = ds.InsertUser(this);
            return status;
        }

        public static User readUser(string email, string password)
        {
            DataServices ds = new DataServices();
            User user = ds.ReadUser(email);

            if (user == null || user.password != password)
            {
                return null // user not exist or password is wrong
            }

            return user;
        }

    }
}