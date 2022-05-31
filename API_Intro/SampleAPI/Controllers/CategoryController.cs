using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleAPI.Controllers
{
    public class CategoryController : ApiController
    {
        //İstediğimiz ID ile değeri döndürme işlemi//

        //Bildiğimiz 1.YOL

        //public Category GetCategoryById(int id)
        // {
        //     List<Category> categories = new List<Category>
        //     {
        //         new Category{ID=1,CategoryName="TestCategory-1",Description="TestDescription-1"},
        //         new Category{ID=2,CategoryName="TestCategory-2",Description="TestDescription-2"},
        //         new Category{ID=3,CategoryName="TestCategory-3",Description="TestDescription-3"}
        //     };
        //    Category category= categories.FirstOrDefault(x => x.ID == id); 
        //     return category;

        // }

        //2.YOL
        public IHttpActionResult Get(int id) //Sonuç döndürmek istiyorsak bu tipi kullanmamız gerekiyor.
        {
            List<Category> categories = new List<Category>
           {
               new Category{ID=1,CategoryName="TestCategory-1",Description="TestDescription-1"},
               new Category{ID=2,CategoryName="TestCategory-2",Description="TestDescription-2"},
               new Category{ID=3,CategoryName="TestCategory-3",Description="TestDescription-3"}
           };

            Category category = categories.FirstOrDefault(x => x.ID == id);

            if (category==null)
            {
                return NotFound(); //Bu tip metotları kullanmamızı sağlayan bir tiptir = IHttpActionResult
            }
            else
            {
                return Ok(category);
            }
        }
    }
}
