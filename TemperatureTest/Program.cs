using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TemperatureTest
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("http://data.fmi.fi/fmi-apikey/9308aac9-b245-47fc-ac0a-aac240dd8a7e/wfs?request=getFeature&storedquery_id=fmi::observations::weather::multipointcoverage&place=pori&parameters=temperature");
            //Debug.WriteLine(doc);

            XNamespace gml = "http://www.opengis.net/gml/3.2";

            String res = (String)
                (from e in doc.Descendants(gml + "doubleOrNilReasonTupleList")
                 select e).First();
            //Debug.WriteLine(res);

            String result = res.Trim().Split('\n').Last().Trim();
            //Debug.WriteLine(result);
        }
    }
}
