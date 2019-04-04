using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3
{
    class Program
    {
        static void Main(string[] args)
        {

            UserInterface userInterface = new UserInterface();
            userInterface.Start();
        }

        public static void SaveXML<T>(T obj, string fileName)
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + fileName;
            System.IO.FileStream file = System.IO.File.Create(path);
            writer.Serialize(file, obj);
            file.Close();
        }


    }
}