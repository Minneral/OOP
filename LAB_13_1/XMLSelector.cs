using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace LAB13
{

    static class XMLSelectors
    {
        public static void Do()
        {
            XPathDocument xDoc = new XPathDocument("Table.xml");
            XPathNavigator navigator = xDoc.CreateNavigator();
            XPathNodeIterator iter = navigator.Select("/ArrayOfTable/Table");
            Console.WriteLine(navigator.SelectSingleNode("/ArrayOfTable").Value);

            while (iter.MoveNext())
            {
                Console.WriteLine(iter.Current.Value);
            }
        }

    }
}