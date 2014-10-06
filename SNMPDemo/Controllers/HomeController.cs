using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SNMPDemo.DAL;
using SNMPDemo.Models;
using SNMPDemo.SNMPTools;
using Quartz;
using System.Globalization;

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
            ViewBag.ID = device.ID;
            ViewBag.IP = device.IpAddress;
            ViewBag.CommunityString = device.CommunityString;
            return PartialView(device);
        }

        [HttpPost]
        public ActionResult _BasicControls(string Ip, string CommunityString, string Action)
        {
            //System.Diagnostics.Debug.WriteLine(Ip + CommunityString + Action);

            if (Action == "On")
                SNMPSet.SendSet(Ip, CommunityString, Action);
            if (Action == "Off")
                SNMPSet.SendSet(Ip, CommunityString, Action);

            return PartialView();
        }

        public ActionResult _PreHeaterTimer(Device device)
        {
            if (MvcApplication.Scheduler.CheckExists(new JobKey("PreHeaterJob" + device.ID, "group1")))
            {
                //System.Diagnostics.Debug.WriteLine("true" + device.ID);
                ViewBag.TimerActive = "true";

                DateTimeOffset? dtoff = MvcApplication.Scheduler.GetTrigger(new TriggerKey("PreHeaterTrigger" + device.ID, "group1")).GetNextFireTimeUtc();
                //DateTime dt = dtoff.Value.ToLocalTime();
                //String s = dt.ToString("MM/dd/yyyy h:mm tt");
                ViewBag.TimerTime = dtoff.Value.ToLocalTime().ToString("dddd, MMM dd yyyy HH:mm", new CultureInfo("en-US"));
                //ViewBag.TimerTime = s;
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine("false" + device.ID);
                ViewBag.TimerActive = "false";
            }

            ViewBag.ID = device.ID;
            ViewBag.IP = device.IpAddress;
            ViewBag.CommunityString = device.CommunityString;

            return PartialView(device);
        }

        [HttpPost]
        public ActionResult _PreHeaterTimer(string Ip, string CommunityString, string DateData, string DeviceId)
        {
            

            if (MvcApplication.Scheduler.CheckExists(new JobKey("PreHeaterJob" + DeviceId, "group1")))
            {
                //System.Diagnostics.Debug.WriteLine("true " + DeviceId);
                ViewBag.TimerActive = "true";

                DateTimeOffset? dtoff = MvcApplication.Scheduler.GetTrigger(new TriggerKey("PreHeaterTrigger" + DeviceId, "group1")).GetNextFireTimeUtc();
                //DateTime dt = dtoff.Value.ToLocalTime();
                //String s = dt.ToString();
                ViewBag.TimerTime = dtoff.Value.ToLocalTime().ToString("dddd, MMM dd yyyy HH:mm", new CultureInfo("en-US"));
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine("false" + DeviceId);
                ViewBag.TimerActive = "false";
            }

            //System.Diagnostics.Debug.WriteLine(Action);
            JobManager.SetTimer(DateData, DeviceId);

            return PartialView();
        }

        [HttpPost]
        public ActionResult _CancelPreHeaterTimer(string DeviceId, string TimerActive)
        {
            MvcApplication.Scheduler.DeleteJob(new JobKey("PreHeaterJob" + DeviceId, "group1"));

            return RedirectToAction("_PreHeaterTimer");
        }
    }
}