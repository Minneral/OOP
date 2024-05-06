using System;
using System.Xml.Serialization;

namespace LAB13
{
    [XmlRoot]
    [Serializable]
    public sealed class Table : Product
    {
        public string Width { get; set; }
        public string Height { get; set; }
        [XmlIgnore]
        public string Shape { get; set; }

        public Table(string name, string price, string width, string height, string shape)
            : base("Table", name, price)
        {
            Width = width;
            Height = height;
            Shape = shape;
        }

        public Table() : this("myName", "myPrice", "myWidth", "myHeight", "myShape") { }

        public override string ToString()
        {
            return $"Shape: {Shape} | Width: {Width} | Height: {Height}";
        }

        public override void SayHi()
        {
            Console.WriteLine("Hi i'm table");
        }

    }
}