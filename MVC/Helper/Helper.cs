using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MVC.Helper
{
    public class UserAPI
    {
        public HttpClient Initial() {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44342/");
                return client;
        }
    }
}