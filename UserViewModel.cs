using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Flight_backend.Controllers;
using Flight_backend.Models;
using Flight_backend.Repository;
using Flight_frontend.Repository;
using Flight_frontend.Models;
using Flight_frontend.Controllers;

namespace Flight_frontend.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "*")]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "*")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "*")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "*")]
        public int Age { get; set; }

        [Required(ErrorMessage = "*")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "*")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "*")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "*")]
        public string Username { get; set; }

        [Required(ErrorMessage = "*")]
        public string Password { get; set; }
    }
}
