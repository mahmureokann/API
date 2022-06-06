using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class MovieController : ApiController
    {
        ImdbDataEntities db = new ImdbDataEntities();
        public IHttpActionResult GetMovies()
        {
            var emploees = db.Movies.Select(x => new MovieDTO
            {
                ID = x.Id,
                Title = x.Title,
                Description = x.Description,
                Year = x.Year,
                Rating = x.Rating
                
            });

            return Json(emploees);
        }
    }
}
