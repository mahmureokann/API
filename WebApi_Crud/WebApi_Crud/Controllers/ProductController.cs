using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Crud.Models;

namespace WebApi_Crud.Controllers
{
    public class ProductController : ApiController
    {

        //Product classı için Crud işlemlerini yazıp test et
        public static List<Product> products = new List<Product>()
        {
            new Product{ID=1,ProductName="Elbise",UnitPrice=250},
            new Product{ID=2,ProductName="Etek",UnitPrice=200},
            new Product{ID=3,ProductName="Yelek",UnitPrice=300}
        };

        public IHttpActionResult GetProduct()
        {
            return Ok(products.ToList());
        }
        public HttpResponseMessage GetProduct(int id)
        {
            var product = products.FirstOrDefault(x => x.ID ==id);
            if (product!= null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, product);
                return response; 
            }
            else
            {
               
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, "ürün bulunamadı");
                return errorResponse;
            }
        }
        public string GetProducts(int id)
        {
            return products[id].ProductName;
        }
        public IHttpActionResult PostProduct(Product product) //Eyleme göre değer döndürceksek.
            
        {
            if (product!=null)
            {
                products.Add(product);
                return Ok(product);

            }
            else
            {
                return BadRequest(); //Hatalı istek
            }
           
        }
        public HttpResponseMessage PutProduct(Product product) //İsteğe göre cevap döndüreceksek
        {
            Product updated = products.FirstOrDefault(x => x.ID == product.ID);

            if (updated == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "ürün bulunamadı");

            }
            else
            {


                updated.ProductName = product.ProductName;
                updated.UnitPrice = product.UnitPrice;
                return Request.CreateResponse(HttpStatusCode.OK, updated);

            }
            
            
            
        }
        public IHttpActionResult DeleteProduct(int id)
        {
            try
            {
                products.Remove(products.Find(x=>x.ID==id));
                return Ok("Ürün silindi");
            }
            catch (Exception ex)
            {

                return BadRequest( ex.Message);
            }
            
        }

        //API baglantı noktalarına Endpoint denilmektedir.
       


    }
}
