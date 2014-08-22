using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SNMPDemo.DAL;
using SNMPDemo.Models;

namespace SNMPDemo.Controllers
{
    public class HomeController : Controller
    {
        private SNMPDemoContext db = new SNMPDemoContext();

        public ActionResult Index()
        {
            return View(db.Devices.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}