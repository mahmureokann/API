﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Authentication.Models.Entity
{
    public class AppUser
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}