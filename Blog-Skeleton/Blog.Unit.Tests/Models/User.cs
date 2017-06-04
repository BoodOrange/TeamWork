﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Unit.Tests.Models
{
    public class User
    {
        public User(string fullname, string email, string password, string newPassword, string confirmPassword)
        {
            FullName = fullname;
            Email = email;
            Password = password;
            PasswordNew = newPassword;
            PasswordConfirm = confirmPassword;
        }

        public User(
            string fullname, 
            string email, 
            string password): this(fullname, email,password,"", password) {}

        public User(
            string fullname, 
            string email, 
            string password, 
            string newPassword) : this(fullname, email, password, newPassword, "") {}

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordNew { get; set; }
        public string PasswordConfirm { get; set; }


    }
}
