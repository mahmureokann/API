using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Northwind.Controllers
{
    public class OrderController : ApiController
    {

        //Siparişleri listeleme işlemleri 

        NORTHWNDEntities1 db = new NORTHWNDEntities1();

        public IHttpActionResult GetOrders() 
        {
            return Ok(db.Orders.ToList());
        }

        public HttpResponseMessage GetOrders(int id)
        {
            Order order = db.Orders.FirstOrDefault(x => x.OrderID == id);

            if (order != null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, db.Orders);
                return response;
            }

            else
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, "sipariş bulunamadı!");
                return errorResponse;
            }
        }
}
