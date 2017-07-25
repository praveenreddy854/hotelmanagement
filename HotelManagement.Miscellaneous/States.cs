using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelManagement.Miscellaneous
{
    public class State
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class StatesXml
    {
        public static dynamic GetAllStates()
        {

            var states = (from s in XDocument.Load(@"C:\Users\prave\OneDrive\Documents\Visual Studio 2017\Projects\Linq2Sql\Linq2Sql\States.xml")
                                        .Descendants("Country").Elements()
                          select new { Name = s.Attribute("name").Value.ToString(), Code = s.Attribute("code").Value.ToString() });

            return states;
        }
    }
}
