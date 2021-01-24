using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestProjectMVC.Models;

namespace TestProjectMVC.Controllers
{
    public class ExportCvsController1 : Controller
    {
        public IActionResult Index()
        {
            return exportCVS();
        }

        public List<TransModel> tmodel = new List<TransModel>();
        private readonly TransDbContext _context;

        public ExportCvsController1(TransDbContext context)
        {
            _context = context;
        }

        public IActionResult exportCVS()
        {
            var bilder = new StringBuilder();
            string csv = string.Empty;
            bilder.AppendLine("Name,Date1,Married,Phone,Salary");
            List<TransModel> blog = _context.Trans.ToList<TransModel>();
            foreach (var item in blog)
            {

                bilder.AppendLine($"{item.Name},{item.Date1},{item.Married},{item.Phone},{item.Salary}");

            }
            return File(Encoding.UTF8.GetBytes(bilder.ToString()), "text/csv", "TransDB.csv");

        }
    }
}


















           
    

