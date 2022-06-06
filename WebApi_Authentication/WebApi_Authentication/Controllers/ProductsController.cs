using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Authentication.Filters;
using WebApi_Authentication.Models.Context;

namespace WebApi_Authentication.Controllers
{
    [BasicAuth]
    public class ProductsController : ApiController
    {
        AppDbContext db = new AppDbContext();
        public HttpResponseMessage GetProducts()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.Products.ToList());
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
