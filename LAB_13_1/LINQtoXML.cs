using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LAB13
{

    static class LINQtoXML
    {
        public static void Do()
        {

            XDocument xdoc = XDocument.Load("Table.xml");

            var items = from xe in xdoc.Element("ArrayOfTable").Elements("Table") select xe.Value;

            foreach (var item in items)
                Console.WriteLine(item);

        }

    }
}