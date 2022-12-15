using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Flight_frontend.Controllers;
using Flight_frontend.Models;
using Flight_frontend.Repository;
using Flight_backend.Repository;
using Flight_backend.Models;
using Flight_backend.Controllers;

namespace Flight_frontend.Models
{
    public class LoginViewModel
    {
        public string userName { get; set; }

        public string Password { get; set; }
    }
}
