using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNMPDemo.Models
{
    public class Device
    {
        public int ID { get; set; }
        public string IpAddress { get; set; }
        public string CommunityString { get; set; }
        public string Description { get; set; }
        public bool showBasicControls { get; set; }
        public bool showPreHeaterTimer { get; set; }
    }
}