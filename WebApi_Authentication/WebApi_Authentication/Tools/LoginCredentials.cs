using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_Authentication.Models.Context;

namespace WebApi_Authentication.Tools
{
    public class LoginCredentials
    {
        
        public static bool AnyUser(string username,string password)
        {
            AppDbContext db = new AppDbContext();
            bool result = db.AppUsers.Any(x => x.Username == username && x.Password == password);
            return result;
        }
    }
}