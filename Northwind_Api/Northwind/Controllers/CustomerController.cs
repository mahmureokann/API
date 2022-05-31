using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Northwind.Controllers
{
    public class CustomerController : ApiController
    {
        //Müşteriler için Listeleme işlemleri

        NORTHWNDEntities1 db = new NORTHWNDEntities1();

        public IHttpActionResult GetCustomer()
        {
            return Ok(db.Customers.ToList());
        }
        public HttpResponseMessage GetCustomer(string id)
        {
            Customer customer = db.Customers.FirstOrDefault(x => x.CustomerID == id);
            if (customer!=null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, db.Customers);
                return response;
            }
            else
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, "müşteri bulunamadı!");
                return errorResponse;
            }
        }

    }
}
