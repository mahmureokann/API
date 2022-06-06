using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiNorthwindAuth.Models.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
    }
}