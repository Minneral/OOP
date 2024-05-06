using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;

namespace LAB13
{

    public class Program
    {
        static void Main(string[] args)
        {

            Table[] Tables = { new Table(), new Table(), new Table() };

            CustomSerializer.XmlSer(Tables);
            CustomSerializer.BinSer(Tables);
            CustomSerializer.SoapSer(Tables);
            CustomSerializer.JSONser(Tables);
            XMLSelectors.Do();
            LINQtoXML.Do();
        }
    }
}