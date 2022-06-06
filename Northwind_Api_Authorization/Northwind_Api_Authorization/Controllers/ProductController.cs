using Northwind_Api_Authorization.Filters;
using Northwind_Api_Authorization.Models;
using Northwind_Api_Authorization.Models.EmployeeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Northwind_Api_Authorization.Controllers
{
    [BasicAuth]
    public class ProductController : ApiController
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        public IHttpActionResult GetProducts()
        {
            var products = db.Products.Select(x => new ProductDTO
            {
                ID = x.ProductID,
                ProductName = x.ProductName,
                UnitInStock = x.UnitsInStock,
                UnitPrice = x.UnitPrice
            }).ToList();

            return Ok(products);
        }
    }
}
