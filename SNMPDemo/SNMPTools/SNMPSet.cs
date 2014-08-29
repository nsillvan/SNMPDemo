using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNMPDemo.SNMPTools
{
    public class SNMPSet
    {
        public void SendSet(String ip, String communitystring)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.FileName = "/C cmd.exe";
            startInfo.Arguments = ip + " " + communitystring;
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}