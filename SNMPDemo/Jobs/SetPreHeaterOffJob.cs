using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using System.Diagnostics;

namespace SNMPDemo.Jobs
{
    public class SetPreHeaterOffJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Debug.WriteLine("Laite pois  " + DateTimeOffset.Now.ToString());
        }
    }
}