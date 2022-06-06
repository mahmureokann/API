using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ProductController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        public IHttpActionResult GetProducts()
        {
            var products = db.Products.Select(x => new ProductDTO
            {
                Id = x.ProductID,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock
            });

            //return Ok(products);
            return Json(products);

        }
    }
}
