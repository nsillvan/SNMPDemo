using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;
using SNMPDemo.Jobs;
using System.Globalization;
using SNMPDemo.DAL;
using SNMPDemo.Models;
using System.Diagnostics;

namespace SNMPDemo
{
    public class JobManager
    {

        public static void SetTimer(string time, string DeviceId)
        {
            SNMPDemoContext db = new SNMPDemoContext();
            Device dev = db.Devices.Find(Int32.Parse(DeviceId));

            string jobIdentity = "PreHeaterJob" + DeviceId;
            string triggerIdentity = "PreHeaterTrigger" + DeviceId;

            // Parse time
            DateTime dt = DateTime.ParseExact(time, "MM/dd/yyyy h:mm tt", CultureInfo.InvariantCulture);
            DateTimeOffset enddto = new DateTimeOffset(dt);
            DateTimeOffset startdto = enddto;
            startdto = startdto.AddHours(-2);
            startdto = startdto.AddMinutes(-30);

            System.Diagnostics.Debug.WriteLine("Jobmanager");
            //System.Diagnostics.Debug.WriteLine(time);
            //System.Diagnostics.Debug.WriteLine(dt);
            //System.Diagnostics.Debug.WriteLine(enddto);
            //System.Diagnostics.Debug.WriteLine(startdto);

            // Build a job
            IJobDetail job = JobBuilder.Create<SetPreHeaterTimerJob>()
                .WithIdentity(jobIdentity, "group1")
                .UsingJobData("ip", dev.IpAddress)
                .UsingJobData("communityString", dev.CommunityString)
                .UsingJobData("deviceId", DeviceId)
                .UsingJobData("enddto", enddto.ToString())
                .Build();

            // Build a trigger
            ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
                .WithIdentity(triggerIdentity, "group1")
                .StartAt(startdto)
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(15)
                    .WithRepeatCount(8))
                .Build();

            // Schedule a job with the trigger
            MvcApplication.Scheduler.ScheduleJob(job, trigger);
            
        }

        public static void TurnOffDevice(string deviceId, DateTimeOffset departureTime)
        {
            SNMPDemoContext db = new SNMPDemoContext();
            //Device dev = db.Devices.Find(Int32.Parse(deviceId));

            string jobIdentity = "PreHeaterOffJob" + deviceId;
            string triggerIdentity = "PreHeaterOffTrigger" + deviceId;

            //DateTimeOffset turnOffTimer = departureTime;
            //turnOffTimer = turnOffTimer.AddMinutes(-5);

            departureTime = departureTime.AddMinutes(-5);

            // Build a job
            IJobDetail job = JobBuilder.Create<SetPreHeaterOffJob>()
                .WithIdentity(jobIdentity, "group1")
                //.UsingJobData("ip", dev.IpAddress)
                //.UsingJobData("communityString", dev.CommunityString)
                .UsingJobData("deviceId", deviceId)
                .Build();

            // Build a trigger
            ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
                .WithIdentity(triggerIdentity, "group1")
                .StartAt(departureTime)
                .Build();

            // Schedule a job with the trigger
            MvcApplication.Scheduler.ScheduleJob(job, trigger);
        }
    }
}