using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleAPI.Controllers
{
    
    public class HomeController : ApiController
    {
        //[HttpGet]
        //public string Index()
        //{
        //    return "Merhaba API!";
        //}

        public static List<string> sampleValues = new List<string> { "Value1", "Value2","Value3" };
        public List<string> GetSampleValues() //Metoda isim verirken, Get olarak isimlendirirsek [HttpGet] yapmamıza gerek kalmaz.

        {
            return sampleValues.ToList();
        }
        
    }
}
