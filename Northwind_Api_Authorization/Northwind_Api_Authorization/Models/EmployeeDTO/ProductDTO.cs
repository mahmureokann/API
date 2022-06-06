using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind_Api_Authorization.Models.EmployeeDTO
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitInStock { get; set; }
       

    }
}