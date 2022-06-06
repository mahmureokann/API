using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        public IHttpActionResult GetEmployees()
        {
            var emploees = db.Employees.Select(x => new EmployeeDTO
            {
                Id = x.EmployeeID,
                Firstname = x.FirstName,
                Lastname = x.LastName,
                Title = x.Title
            });

            return Json(emploees);
        }
    }
}
