
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.Security;
using Flight_backend.Models;
using Flight_frontend.Models;
using Flight_frontend.Repository;

namespace Flight_frontend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                UserViewModel newUser = new UserViewModel();
                var service = new ServiceRepository();
                {

                    using (var response = service.PostResponse("http://localhost:44319/Register/CreateUser", user))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        newUser
                            = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }

                return RedirectToAction("RegisterUser");
            }
            return View(user);
        }

        



        [HttpPost]
        public ActionResult RegisterUserZ(UserRegisterModel Ur)
        {
            //RegisterController reg = new RegisterController();

            if (ModelState.IsValid)
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("http://localhost:44319/Register/custregform");
                var insertrec = hc.PostAsJsonAsync<UserRegisterModel>("custregform", Ur);//Asynchronosly passing the values in Json Format to API
                var savrec = insertrec.Result;//Saving the User Details 

                //Condition for Successfull Registartion 
                if ((int)savrec.StatusCode == 200)
                {
                    ViewBag.Successmessage = "Successfully Registered!!!!!";
                }
                //Condition for User Already Existing Check
                if ((int)savrec.StatusCode == 422)
                {
                    ViewBag.userAlreadymessage = "User Name Already Exist, please provide a new User Name";
                }
                //Condition for Mobile Num Should be 10 digits
                if ((int)savrec.StatusCode == 423)
                {
                    ViewBag.MobileLengthmessage = "Mobile Num Should be 10 Digits Only";
                }
                //Condition for Mobile Num Already Exist
                if ((int)savrec.StatusCode == 424)
                {
                    ViewBag.MobileExistmessage = "Mobile Num Already Exist, please provide a new Mobile Number";
                }
                //Condition for Email Id Already Exist
                if ((int)savrec.StatusCode == 425)
                {
                    ViewBag.EmailExistmessage = "Email Already Exist, please provide a new Email ID";
                }
            }
            return View();

        }


        //This Action method is used to display Login View
        public ActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LoginUser(LoginViewModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserViewModel newUser = new UserViewModel();
                    var service = new ServiceRepository();
                    {
                        using (var response = service.VerifyLogin("api/Account/Login", login))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                        }
                    }
                    if (newUser != null)
                    {
                        ViewBag.message = "Login Success";
                    }
                    else
                    {
                        ViewBag.message = "incorrect";
                    }
                }
            }
            catch
            {

            }
            return View("HomePage");

        }

        //This Post Method will validate the userName & Password valid or not using WebAPI
        [HttpPost]
        public ActionResult LoginUserZ(UserRegisterModel Ur)
        {
            if (!(string.IsNullOrEmpty(Ur.Username) || string.IsNullOrEmpty(Ur.Password)))
            {

                if (!ModelState.IsValid)
                {
                    HttpClient hc = new HttpClient();
                    hc.BaseAddress = new Uri("http://localhost:44319/Register/custLogin"); // URL for Login WebAPI
                    var checkLoginDetails = hc.PostAsJsonAsync<UserRegisterModel>("custLogin", Ur);//Asynchronosly passing the values in Json Format to API
                    var checkrec = checkLoginDetails.Result;//Checking the User Login ID & Password 

                    //Condition for Successfull Login We need to Navigate to Flght Seach Page 
                    if ((int)checkrec.StatusCode == 200)
                    {
                        ViewBag.message = "Login Success!!";
                    }
                    //Condition for Invalid User Name & Password
                    if ((int)checkrec.StatusCode == 426)
                    {
                        ViewBag.message = "Invalid User Id & Password";
                    }
                }
            }
            return View();

        }
    }
}
