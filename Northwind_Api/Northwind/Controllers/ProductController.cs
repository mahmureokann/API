using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Northwind.Controllers
{
    public class ProductController : ApiController
    {
        //API crud işlemleri

        //Northwind db kuruyoruz

        NORTHWNDEntities1 db = new NORTHWNDEntities1();

        //Urunlerin listelenmesi
        public IHttpActionResult GetProduct()
        {
            return Ok(db.Products.ToList());
        }
        public HttpResponseMessage GetProduct(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.ProductID==id);
            if (product==null)
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, "ürün bulunamadı!");
                return errorResponse;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, db.Products);
                return response;
            }
        }

        //Ürün ekleme
        public IHttpActionResult PostProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest(); //hatalı istek
            }
            else
            {
                db.Products.Add(product);
                return Ok(product.ProductName + " eklendi!");
            }
        }
        //Ürün silme
        public IHttpActionResult DeleteProduct(int id)
        {
            try
            {
                Product product = db.Products.FirstOrDefault(x => x.ProductID == id);

                return Ok(product.ProductName+" silindi!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message); //hatalı istek
            }

        }
        //Ürün güncelleme
        public HttpResponseMessage PutProduct(Product product)
        {
           
            Product updated = db.Products.FirstOrDefault(x => x.ProductID == product.ProductID);
            if (updated != null)
            {
                updated.ProductID = product.ProductID;
                updated.ProductName = product.ProductName;
                updated.UnitPrice = product.UnitPrice;
                updated.UnitsInStock = product.UnitsInStock;

                return Request.CreateResponse(HttpStatusCode.OK, updated);
              

            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "ürün bulunamadı!");
            }
        }

        

    }
}
