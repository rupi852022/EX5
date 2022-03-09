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
        string email;
        string password;
        string gender
        string phoneNumber

        public User(string fName, string lName, string email, string password, string gender, string phoneNumber, int id)
        {
            this.fName = fName;
            this.lName = lName;
            this.email = email;
            this.password = password;
            this.gender = gender;
            this.phoneNumber = phoneNumber;
            this.id = id;
        }

        public User() { }
        public string FName { get => fName; set => fName = value; }
        public string LName { get => lName; set => lName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Gender { get => gender; set => gender = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
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