using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flight_backend.Controllers;
using Flight_backend.Models;
using Flight_backend.Repository;

namespace Flight_backend.Models
{
    public class Login
    {
        public string userName { get; set; }

        public string password { get; set; }

    }
}
