using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Authentication.Models.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        
    }
}