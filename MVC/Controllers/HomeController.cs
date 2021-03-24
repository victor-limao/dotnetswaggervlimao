using DotNetSwaggerVictorLimao.Models;
using System.Web.Script.Serialization;
using Microsoft.AspNetCore.Mvc;
using MVC.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        UserAPI api = new UserAPI();
        public async Task<ActionResult> Index()
        {
            ViewBag.Message = "Home.";
            List<UserData> users = new List<UserData>();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/users");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<UserData>>(results);
            }
            return View(users);
        }
        public async Task<ActionResult> Details(int id)
        {
            var user = new UserData();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/users/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<UserData>(results);
            }
            return View(user);
        }
        public ActionResult Create()
        {
            ViewBag.Message = "Crie um novo usuário.";


            return View();
        }
        [HttpPost]
        public ActionResult Create(UserData user)
        {
            if (user.Gender == "M" || user.Gender == "F")
            {
                HttpClient client = api.Initial();

                var postTask = client.PostAsJsonAsync<UserData>("api/users", user);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
           
            return View();
        }
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Message = "Faça a edição do usuário.";

            var user = new UserData();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/users/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<UserData>(results);
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(UserData user)
        {
            HttpClient client = api.Initial();

            var json = JsonConvert.SerializeObject(user);
            var stringContent = new StringContent(json, System.Text.UnicodeEncoding.UTF8, "application/json");
            var putTask = client.PutAsync("api/users", stringContent);
            //putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        public async Task<ActionResult> Delete(int id)
        {

            var user = new UserData();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/users/{id}");

            return RedirectToAction("Index");
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}