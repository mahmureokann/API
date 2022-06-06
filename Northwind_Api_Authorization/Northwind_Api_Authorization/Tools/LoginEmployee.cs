using Northwind_Api_Authorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind_Api_Authorization.Tools
{
    public class LoginEmployee
    {
        public static bool AnyEmployee(string firstName,string lastName)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();

            bool result = db.Employees.Any(x => x.FirstName == firstName && x.LastName == lastName);
            return result;
        }
    }
}