using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using perpustakaku_client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace perpustakaku_client.Controllers
{
    public class BookController : Controller
    {
        readonly HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            ViewBag.rak = List_Rak();
            ViewBag.jenis = List_Jenis();
            return View();
        }

        public IList<Rak> List_Rak()
        {
            IList<Rak> rak = null;
            var responsetask = client.GetAsync("https://localhost:44395/api/Rak/GetDropRak");
            responsetask.Wait();
            var result = responsetask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Rak>>();
                readTask.Wait();
                rak = readTask.Result;
                return ViewBag.rak = rak;
            }
            return ViewBag.rak = rak;
        }
        public IList<Jenis> List_Jenis()
        {
            IList<Jenis> jenis = null;
            var responsetask = client.GetAsync("https://localhost:44395/api/Jenis/GetDropJenis");
            responsetask.Wait();
            var result = responsetask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Jenis>>();
                readTask.Wait();
                jenis = readTask.Result;
                return ViewBag.jenis = jenis;
            }
            return ViewBag.jenis = jenis;
        }
    }
    
}
