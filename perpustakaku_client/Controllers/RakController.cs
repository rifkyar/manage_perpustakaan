using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using perpustakaku_client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace perpustakaku_client.Controllers
{
    public class RakController : Controller
    {
        readonly HttpClient client = new HttpClient();

        public RakController()
        {
            client.BaseAddress = new Uri("https://localhost:44395/api/");
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult Create()
        {
            SaveRak rak = new SaveRak();
            rak.Value = Request.Form["Value"].ToString();
            var myContent = JsonConvert.SerializeObject(rak);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var create = client.PostAsync("Rak/SaveRak", ByteContent).Result;
            return Json(new { data = create });
        }
        public JsonResult Delete(int Id)
        {
            var delete = client.GetAsync("Rak/DeleteRak?Id=" + Id).ToString();
            return Json(new { data = delete });
        }
    }
}
