using kiramtush.Migrations;
using kiramtush.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace kiramtush.Controllers
{
    public class HomeController : Controller
    {   
        public IActionResult delete(kala s)
        {
            KiramtushDb db = new KiramtushDb();
            var a = db.kalas.FirstOrDefault(x => x.Id == s.Id);
            if (a == null)
            {
                return View("delete");
            }
            else
            {
				db.kalas.Remove(a);
                db.SaveChanges();
				return View("Login");
			}

        }
        public IActionResult search(int a , int b)
        {
            KiramtushDb db = new KiramtushDb();
            var aa =db.kalas.Where(x => x.Price >= a && x.Price <= b).ToList();
            return View("search",aa);
        }
        public IActionResult ListKala()
        {
            KiramtushDb db = new KiramtushDb();
            var a = db.kalas.ToList();
            return View("ListKala",a);
        }
        public IActionResult Save(moshtari asp)
        {
            KiramtushDb db = new KiramtushDb();
            db.moshtaris.Add(asp);
            db.SaveChanges();
            return View("vas");
        }
        public IActionResult Login(moshtari abc)
        {
            KiramtushDb db = new KiramtushDb();
            var f = db.moshtaris.FirstOrDefault(x => x.Username == abc.Username && x.Password == abc.Password);
            if (f == null)
            {
                
                return View();
            }
            else
            {
                
                return View("Save",f);
            }

        }
            public IActionResult Edit(moshtari abc)
            {
                KiramtushDb db = new KiramtushDb();
                var a = db.moshtaris.FirstOrDefault(x => x.Id == abc.Id);
                if (a != null)
                {
                   a.Password = abc.Password;
                   a.ConfirmPassword = abc.ConfirmPassword;
                   db.SaveChanges();
                   return View("Save");
                }
                else
                {
                  return View("Edit");
            }
        }
        public IActionResult Product(kala assp)
        {
            KiramtushDb db = new KiramtushDb();
            db.kalas.Add(assp);
            db.SaveChanges();
            return RedirectToAction("ListKala");
        }

        public IActionResult sabtkala()
        {
            return View();
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
    }
}
