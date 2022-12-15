using Flight_backend.Models;
using Flight_backend.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using Flight_backend.Controllers;


namespace Flight_backend.Controllers
{

    public class RegisterController : ApiController
    {
        private IDataRepository<Customer> _dataRepository;

        public RegisterController()
        {
            this._dataRepository = new UserRepository(new RegisterDBEntities());
        }

        [HttpPost]
        public IHttpActionResult CreateUser([FromBody] Customer userObj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dataRepository.Add(userObj);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(userObj);
        }

       
        
        RegisterDBEntities objRegisterDBEntities;

        public IHttpActionResult custregform(UserRegisterModel Ur)
        {

            RegisterDBEntities nd = new RegisterDBEntities();

            if (nd.Customers.Any(model => model.Username == Ur.Username))
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse((HttpStatusCode)422, new HttpError("Something goes wrong")));
            }

            else if (Ur.MobileNumber.Length > 10)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse((HttpStatusCode)423, new HttpError("Something goes wrong")));
            }

            else if (nd.Customers.Any(model => model.MobileNumber == Ur.MobileNumber))
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse((HttpStatusCode)424, new HttpError("Something goes wrong")));
            }

            else if (nd.Customers.Any(model => model.EmailID == Ur.EmailID))
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse((HttpStatusCode)425, new HttpError("Something goes wrong")));
            }

            else
            {
                nd.Customers.Add(new Customer()
                {
                    CustomerID = Ur.CustomerID,
                    Firstname = Ur.Firstname,
                    Lastname = Ur.Lastname,
                    Age = Ur.Age,
                    Gender = Ur.Gender,
                    EmailID = Ur.EmailID,
                    MobileNumber = Ur.MobileNumber,
                    Username = Ur.Username,
                    Password = Ur.Password,
                });
                nd.SaveChanges();
                return Ok();
            }

        }

        public IHttpActionResult custLogin(UserRegisterModel Ur)
        {
            RegisterDBEntities nd = new RegisterDBEntities();

            var checkValidUser = objRegisterDBEntities.Customers.Where(m => m.Username == Ur.Username &&
            m.Password == Ur.Password).FirstOrDefault();

            if (checkValidUser != null)
            {
                return Ok();
            }

            else
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse((HttpStatusCode)426, new HttpError("Something goes wrong")));
            }
        }

    }
}
