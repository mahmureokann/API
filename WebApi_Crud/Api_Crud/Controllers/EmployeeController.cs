using Api_Crud.Models;
using Api_Crud.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_Crud.Controllers
{
    public class EmployeeController : ApiController
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

       //EmployeeDTO listesi 
       public List<EmployeeDTO> EmployeeList()
        {
            var employees = db.Employees.Select(x => new EmployeeDTO { ID = x.EmployeeID, Firstname = x.FirstName, Lastname = x.LastName, Title = x.Title }).ToList();
            return employees;
        }

        //Listeden sonra employeeları getirmemiz gerekiyor
        public IHttpActionResult GetEmployee()
        {
            return Json(EmployeeList());
        }
        [HttpDelete]
        public IHttpActionResult DeleteEmployees(int id)
        {
            var employee = db.Employees.Find(id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
                return Json(EmployeeList());
            }
            else
            {
                return BadRequest(); //Hatalı istek döndür

            }
        }
            

    }
}
