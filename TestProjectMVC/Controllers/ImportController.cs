using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectMVC.Models;



namespace TestProjectMVC.Controllers
{
    public class ImportController : Controller
    {
        private readonly TransDbContext _context;

        public ImportController(TransDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile files)
        {
            if (files != null)
            {
                try
                {
                    if (files.Length > 0)
                    {
                        string fileExtension = Path.GetExtension(files.FileName);
                        if (fileExtension != ".csv")
                        {
                            ViewBag.Message = "Please select the csv file with .csv extension";
                            return View();
                        }
                        var trans = new List<TransModel>();
                        var sreader = new StreamReader(files.OpenReadStream());
                        string[] headers = sreader.ReadLine().Split(',');
                        while (!sreader.EndOfStream)
                        {
                            string[] rows = sreader.ReadLine().Split(',');
                            var objfiles = new TransModel()
                            {

                                Name = rows[0].ToString(),
                                Date1 = DateTime.Parse(rows[1].ToString()),
                                Married = bool.Parse(rows[2].ToString()),
                                Phone = rows[3].ToString(),
                                Salary = int.Parse(rows[4].ToString())

                            };
                            _context.Trans.Add(objfiles);
                        }

                        using (var target = new MemoryStream())
                        {
                            files.CopyTo(target);
                        }

                        _context.SaveChanges();

                    }
                    return RedirectToAction("Index", "Trans");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                }
            }
            else
            {
                ViewBag.Message = "Please select the file first to upload.";
            }
                return View();
            }
    }
}

