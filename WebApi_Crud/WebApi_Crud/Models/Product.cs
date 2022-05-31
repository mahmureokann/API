using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Crud.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

    }
}