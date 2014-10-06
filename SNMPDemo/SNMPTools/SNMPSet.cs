using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNMPDemo.SNMPTools
{
    public class SNMPSet
    {
        public static void SendSet(string ip, string communitystring, string action)
        {
            string val;

            if (action == "On")
                val = "1";
            else
                val = "0";

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = @"C:\Users\IoT\Downloads\1_SNMPDemo-master\SNMPDemo-master\SNMPDemo\Resources\SnmpSet.exe";
            //startInfo.Arguments = ip + " " + communitystring;
            startInfo.Arguments = @"/C SnmpSet.exe -r:192.168.0.11 -c:""public"" -o:0.1.3.6.1.4.1.21287.16.1.0 -val:" + val;
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}