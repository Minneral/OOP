using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LAB13
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
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Table[]));
            using (FileStream fs = new FileStream("Table.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, an);
                Console.WriteLine("Объект успешно сериализован в JSON файл!");
            }
            using (FileStream fs = new FileStream("Table.json",
            FileMode.OpenOrCreate))
            {
                Table[] an2 = (Table[])jsonFormatter.ReadObject(fs);
                Console.WriteLine("Объект десериализован с JSON файла!");

                foreach (var item in an2)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }

}