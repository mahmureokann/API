using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi_Crud.Controllers
{
    public class HomeController : ApiController
    {
        
        public static List<string> sampleValues = new List<string>
        {
            "Value1","Value2","Value3"
        };
       
        public string GetSampleValues(int id)
        {
            return sampleValues[id];
        }

        public string PostValue([FromBody]string value) //ön ek post olduğu için gönderme işlemi gerçekleştirecek [FromBody]= Bodyden bir değer gelecek demiş olduk.
        {
            sampleValues.Add(value);
            return value + " => eklendi!";
        }
        public string DeleteValue(int id) //Silme
        {
            sampleValues.Remove(sampleValues[id]);
            return "Veri silindi!";
        }

        public string PutValue(int id,[FromBody]string value) //Güncelleme [FromBody] yalnızca string ifadelerde kullanıyoruz
        {
            sampleValues[id] = value;
            return "Veri güncellendi!";
        }

    }
}
