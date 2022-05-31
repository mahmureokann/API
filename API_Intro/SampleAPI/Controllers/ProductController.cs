using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleAPI.Controllers
{
    public class ProductController : ApiController
    {
        IEnumerable<Product> GetFakeProduct //IEnumerable kendi içerisinde foreach barındıran bir interfacetir.List tipi yerine bu tipi kullandık
        {
            get
            {
                return new List<Product> { new Product
                {
                    ProductName ="Product 1",
                    UnitPrice = 5

                },
                new Product
                {
                    ProductName ="Product 2",
                    UnitPrice = 15
                },
                new Product
                {
                    ProductName ="Product 3",
                    UnitPrice = 20
                }
                };
            }
        }


        public HttpResponseMessage Get() //Protokolden dönen cevaba istinaden HttpResponseMessage dönsün
        {
            var product = GetFakeProduct.ToList();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK,product); //çözüm için istek olması gerekiyor. Response = çözüm request = istek.
            return response; //Eğer ok ise productları yolla.
        }
    }
}
