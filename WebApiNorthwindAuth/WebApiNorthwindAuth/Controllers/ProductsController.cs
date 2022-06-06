using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiNorthwindAuth.Filters;
using WebApiNorthwindAuth.Models;
using WebApiNorthwindAuth.Models.DTO;

namespace WebApiNorthwindAuth.Controllers
{
   [BasicAuthFilter]
    public class ProductsController : ApiController
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        
        public IHttpActionResult GetProducts()
        {
            var products = db.Products.Select(x => new ProductDTO
            {
                Id = x.ProductID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock
            }).ToList();
            return Ok(products);
        }
    }
}
