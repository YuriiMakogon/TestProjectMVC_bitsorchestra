using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectMVC.Models;

namespace TestProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //private List<TransModel> tmodel = new List<TransModel>();
        //public TransDbContext tb;


        //public IActionResult CVS()
        //{
        //    var bilder = new StringBuilder();

        //    string csv = string.Empty;




        //    bilder.AppendLine("Name,Date1,Married,Phone,Salary");
        //    foreach (var item in tmodel)
        //    {
        //        bilder.AppendLine($"{item.Name},{item.Date1},{item.Married},{item.Phone},{item.Salary}");

        //    }
        //    return File(Encoding.UTF8.GetBytes(bilder.ToString()), "text/cvs", "TransDB.CVS");
        //}

    }
}