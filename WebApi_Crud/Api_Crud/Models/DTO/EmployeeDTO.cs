using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Crud.Models.DTO
{
    public class EmployeeDTO
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; }
    }
}