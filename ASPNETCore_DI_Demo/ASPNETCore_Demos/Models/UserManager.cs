
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore_Demos.Models
{
    public static class UserManager
    {
        public static Boolean ValidateUser(String login, String password)
        {
            if (login == "admin" && password == "admin")
                return true;
            else return false;
        }

        public static List<User> GetUsers()
        {
            var list = new List<User>();
            list.Add(new User() { Name = "Bilal", Age = 100 });
            list.Add(new User() { Name = "Shahzad", Age = 100 });

            return list;
        }
    }

    public class User
    {
        public String Name { get; set; }
        public int Age { get; set; }
    }

    public class LoginDTO
    {
        public String Login { get; set; }
        public String Password { get; set; }
    }
}
