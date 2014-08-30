using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SNMPDemo.DAL;
using SNMPDemo.Models;
using SNMPDemo.SNMPTools;
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

        public ActionResult _BasicControls(Device device)
        {
            //Device device = new Device();
            //device = db.Devices.Find(id);
            //return PartialView(device);
            ViewBag.ID = device.ID;
            ViewBag.IP = device.IpAddress;
            ViewBag.CommunityString = device.CommunityString;
            return PartialView(device);
        }

        [HttpPost]
        public ActionResult _BasicControls(string Ip, string CommunityString)
        {
            //Device device = new Device();
            //device = db.Devices.Find(Request.Form["btn"]);

            //String str = Request.Params["btn"];
            //if (str == "Turn On")
            //{
            //    SNMPSet.SendSet();
            //}
            //if (str == "Turn Off")
            //{
                
            //}

            //Device device = new Device();
            //device = db.Devices.Find(1);
            //System.Diagnostics.Debug.WriteLine(Ip, CommunityString);
            SNMPSet.SendSet(Ip, CommunityString);

            return PartialView();
        }
    }
}