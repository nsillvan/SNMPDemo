using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using System.Xml.Linq;
using System.Diagnostics;
using SNMPDemo.SNMPTools;
using System.Timers;
using System.Globalization;

namespace SNMPDemo.Jobs
{
    public class SetPreHeaterTimerJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string ip = dataMap.GetString("ip");
            string communityString = dataMap.GetString("communityString");
            string enddtoString = dataMap.GetString("enddto");
            string deviceId = dataMap.GetString("deviceId");
            //DateTimeOffset enddto = new DateTimeOffset();
            //enddto = DateTimeOffset.ParseExact(enddtoString, "dd.MM.yyyy h:mm zzz", CultureInfo.InvariantCulture);

            DateTimeOffset departureTime;
            departureTime = DateTimeOffset.Parse(enddtoString);

            //Debug.WriteLine(enddto.ToString());
            //Debug.WriteLine(enddtoString);
            //Debug.WriteLine(DateTimeOffset.Now);

            double temperature = Double.Parse(GetTemperature(), CultureInfo.InvariantCulture);
            //string tempresult = GetTemperature();
            //temperature = Double.Parse(tempresult, CultureInfo.InvariantCulture);
            Debug.WriteLine(temperature);
            //double temperature = 20;
            double hoursToWarm = 0.5 - (temperature * 0.1);

            TimeSpan hoursToDeparture = departureTime.Subtract(DateTimeOffset.Now);

            //Debug.WriteLine(hoursToDeparture);

            //double hoursToDeparture2 = hoursToDeparture.TotalHours;

            if (hoursToWarm >= hoursToDeparture.TotalHours)
            {
                Debug.WriteLine("Laite paalle!" + " hoursToWarm: " + hoursToWarm + " hoursToDeparture: " + hoursToDeparture.TotalHours + "  Kello on: " + DateTimeOffset.Now.ToString());
                MvcApplication.Scheduler.PauseJob(new JobKey("PreHeaterJob" + deviceId, "group1"));
                JobManager.TurnOffDevice(deviceId, departureTime);
            }
            else
                Debug.WriteLine("Odota..." + " hoursToWarm: " + hoursToWarm + " hoursToDeparture: " + hoursToDeparture.TotalHours + "  Kello on: " + DateTimeOffset.Now.ToString());
            
        }

        public String GetTemperature()
        {
            //Debug.WriteLine(DateTime.Now.ToString() + "Moikka");

            XDocument doc = XDocument.Load("http://data.fmi.fi/fmi-apikey/9308aac9-b245-47fc-ac0a-aac240dd8a7e/wfs?request=getFeature&storedquery_id=fmi::observations::weather::multipointcoverage&place=pori&parameters=temperature");
            //Debug.WriteLine(doc);

            XNamespace gml = "http://www.opengis.net/gml/3.2";

            String res = (String)
                (from e in doc.Descendants(gml + "doubleOrNilReasonTupleList")
                 select e).First();
            //Debug.WriteLine(res);

            String result = res.Trim().Split('\n').Last().Trim();

            return result;
        }

    }
}