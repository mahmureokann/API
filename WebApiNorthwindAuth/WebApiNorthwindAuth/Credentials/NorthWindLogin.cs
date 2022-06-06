using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiNorthwindAuth.Models;

namespace WebApiNorthwindAuth.Credentials
{
    public class NorthWindLogin
    {
        public static bool AnyEmployee(string firstName, string lastName)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            bool result = db.Employees.Any(x => x.FirstName == firstName && x.LastName == lastName);
            return result;
        }
    }
}