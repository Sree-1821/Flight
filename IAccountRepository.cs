using Flight_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flight_backend.Controllers;
using Flight_backend.Repository;

namespace Flight_backend.Repository
{
    internal interface IAccountRepository
    {
        Customer VerifyLogin(string userName, string password);

    }
}
