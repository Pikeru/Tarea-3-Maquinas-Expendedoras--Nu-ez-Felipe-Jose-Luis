using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization;


namespace Tarea3
{
    [Serializable()]
    public class Product : ISerializable
    {

        //Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        //Constructors

        public Product(int id, string name, double price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public Product()
        {
            Id = 0;
            Name = "";
            Price = 0;
            Quantity = 0;
        }

        //Methods

        public override string ToString()
        {
            return String.Format("{0} ID: {1} Price:{2} Quantity: {3}", Name, Id, Price, Quantity);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Name", Name);
            info.AddValue("Price", Price);
            info.AddValue("Quantity", Quantity);
        }

        public Product(SerializationInfo info, StreamingContext ctxt)
        {
            Id = (int)info.GetValue("Id", typeof(int));
            Name = (string)info.GetValue("Name", typeof(string));
            Price = (double)info.GetValue("Price", typeof(double));
            Quantity = (int)info.GetValue("Quantity", typeof(int));

        }
    }
}