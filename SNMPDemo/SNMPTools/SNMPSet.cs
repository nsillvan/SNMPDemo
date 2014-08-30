using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNMPDemo.SNMPTools
{
    public class SNMPSet
    {
        public static void SendSet(string ip, string communitystring)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = ip + " " + communitystring;
            startInfo.Arguments = "/C ipconfig";
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}