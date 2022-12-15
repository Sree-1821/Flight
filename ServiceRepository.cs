using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using Flight_backend.Models;
using Flight_backend.Controllers;
using Flight_backend.Repository;
using Flight_frontend.Repository;
using Flight_frontend.Models;
using Flight_frontend.Controllers;

namespace Flight_frontend.Repository
{
    public class ServiceRepository
    {
        HttpClient client;

        public ServiceRepository()
        {
            client = new HttpClient();
            // client.BaseAddress = new Uri("http://localhost:44319/Register/CreateUser");
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiBaseURL"].ToString());
        }
        public HttpResponseMessage PostResponse(string url, object model)
        {
            return client.PostAsJsonAsync(url, model).Result;
        }

        public HttpResponseMessage VerifyLogin(string url, object model)
        {
            return client.PostAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage GetResponse(string url)
        {
            return client.GetAsync(url).Result;
        }
    }
}
