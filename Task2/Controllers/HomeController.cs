using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListView()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult DetailView(long id)
        {
            ViewBag.Message = "My contact page.";
            return View( new Tuple<long, Contact> (id, MemoryContactRepository.Singleton.Read(id)) );
        }
    }
}