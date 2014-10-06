using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Globalization;

namespace TimeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var offset = DateTimeOffset.Now;
            //Debug.WriteLine(offset);

            //Debug.WriteLine(DateTimeOffset.UtcNow);

            //String s = "10/1/2014 6:17 PM";
            //DateTime dt = DateTime.ParseExact(s, "MM/dd/yyyy h:mm tt", CultureInfo.InvariantCulture);
            //DateTimeOffset dto = new DateTimeOffset(dt);
            DateTimeOffset dto1 = new DateTimeOffset();



            dto1 = DateTimeOffset.Now;
            dto1 = dto1.AddHours(2);
            dto1 = dto1.AddMinutes(30);

            Debug.WriteLine(DateTimeOffset.Now);
            Debug.WriteLine(dto1);

            TimeSpan diff = dto1.Subtract(DateTimeOffset.Now);
            Debug.WriteLine(diff);
            Debug.WriteLine(diff.TotalHours);
            Debug.WriteLine(diff.TotalSeconds);
            var diffsec = (DateTimeOffset.Now - dto1).TotalSeconds;
            Debug.WriteLine(diffsec);
            


            //dtoff.Value.ToLocalTime().ToString("dddd, MMM dd yyyy HH:mm", new CultureInfo("en-US"));


            //Debug.WriteLine(dto1);
            //Debug.WriteLine(dto2);
            //Debug.WriteLine(DateTimeOffset.Now);
            //Debug.WriteLine(dto1 - DateTimeOffset.Now);
            //Debug.WriteLine(DateTimeOffset.Now - dto1);
            //Debug.WriteLine(dto1.CompareTo(DateTimeOffset.Now));
            //Debug.WriteLine(DateTimeOffset.Now.CompareTo(dto1));
            //Debug.WriteLine("  ");

            //Debug.WriteLine(dto1.Hour);

            double temp = -26;
            double res = 0;
            for (int i = 0; i < 40; i++)
            {
                temp++;
                res = 0.5 - (temp * 0.1);
                Debug.WriteLine("Temp: " + temp + "  Result: " + res);
            }

            //Debug.WriteLine(s);
            //Debug.WriteLine(dt.ToString());
            //Debug.WriteLine(dt.ToUniversalTime().ToString());
            //Debug.WriteLine(dto.ToString());
        }
    }
}
