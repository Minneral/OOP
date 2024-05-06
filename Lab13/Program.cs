using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.ConstrainedExecution;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;
using System.Runtime.InteropServices.ComTypes;

namespace Lab13
{
    static class CustomSerializer
    {
        public static void XmlSer(Table[] an)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Table[]));

            using (FileStream fs = new FileStream("Table.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, an);
                Console.WriteLine("Объект успешно сериализован в XML файл!");
            }

            using (FileStream fs = new FileStream("Table.xml", FileMode.OpenOrCreate))
            {
                Table[] Tables = (Table[])xml.Deserialize(fs);

                Console.WriteLine("Объект десериализован с XML файла!");

                foreach (Table Table in Tables)
                {
                    Console.WriteLine(Table.ToString());
                }
            }

            Console.WriteLine();
        }

        public static void BinSer(Table[] an)
        {
            BinaryFormatter Bin = new BinaryFormatter();

            using (FileStream fs = new FileStream("Table.dat", FileMode.OpenOrCreate))
            {
                Bin.Serialize(fs, an);
                Console.WriteLine("Объект успешно сериализован в BIN!");
            }

            using (FileStream fs = new FileStream("Table.dat", FileMode.OpenOrCreate))
            {
                Table[] Tables = (Table[])Bin.Deserialize(fs);

                Console.WriteLine("Объект десериализован с BIN!");

                foreach (Table Table in Tables)
                {
                    Console.WriteLine(Table.ToString());
                }
            }

            Console.WriteLine();
        }

 
        public static void SoapSer(Table[] an)
        {
            SoapFormatter Soap = new SoapFormatter();

            using (FileStream fs = new FileStream("Table.soap", FileMode.OpenOrCreate))
            {
                Soap.Serialize(fs, an);
                Console.WriteLine("Объект успешно сериализован в SOAP файл!");
            }

            using (FileStream fs = new FileStream("Table.soap", FileMode.OpenOrCreate))
            {
                Table[] Tables = (Table[])Soap.Deserialize(fs);

                Console.WriteLine("Объект десериализован с SOAP файла!");

                foreach (Table Table in Tables)
                {
                    Console.WriteLine(Table.ToString());
                }
            }

            Console.WriteLine();
        }

        public static void JSONser(Table[] an)
        {
            string json = JsonConvert.SerializeObject(an);
            Console.WriteLine("Объект успешно сериализован в JSON!");

            Table[] restoredPerson = JsonConvert.DeserializeObject<Table[]>(json);
            Console.WriteLine("Объект десериализован с JSON!");

            foreach (Table Table in restoredPerson)
            {
                Console.WriteLine(Table.ToString());
            }

            Console.WriteLine();
        }
    }

    static class XmlSelectors
    {
        public static void Do()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Table.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("Table");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);

            Console.ReadLine();
        }

        public static void ser()
        {
            #region linq to xml

            XDocument xdoc = XDocument.Load("xpath.xml");

            var items = from xe in xdoc.Element("ArrayOfTable").Elements("Table") select xe.Value;

            foreach (var item in items)
                Console.WriteLine(item);
            #endregion


        }

    }

    static class LINQtoXML
    {
        public static void Do()
        {
            #region linq to xml

            XDocument xdoc = XDocument.Load("xpath.xml");

            var items = from xe in xdoc.Element("ArrayOfTable").Elements("Table") select xe.Value;

            foreach (var item in items)
                Console.WriteLine(item);
            #endregion


        }

    }



    public class Program
    {
        static void Main(string[] args)
        {
           
            Table[] Tables = { new Table(), new Table(), new Table() };

            CustomSerializer.XmlSer(Tables);
            CustomSerializer.BinSer(Tables);
            CustomSerializer.SoapSer(Tables);
            CustomSerializer.JSONser(Tables);

            XmlSelectors.Do();
            Console.WriteLine("fdfd");
        }
    }
}
