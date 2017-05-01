using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AuthDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "MaltheOnly")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            var ident = User.Identity as ClaimsIdentity;
            var nameClaim = ident.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

            if (nameClaim != null && nameClaim.Value == "Malthe Kirkhoff Stougaard")
            {
                // you are good to go!
            }

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
