namespace Psgk.CarInspect.CarDataUSvc.Logic
{

    using Psgk.CarInspect.CarDataUSvc.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.Json;
    using System.Xml;
    using System.Xml.Serialization;

    public class CarReader
    {
        public List<Car> ReadCars(string filename)
        {
            string file = "";
            if (Directory.GetCurrentDirectory().Contains(@"\bin\Debug"))
            {
                file = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName).FullName, filename);
            }
            else
            {
                file = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, filename);
            }

            List<Car> cars = new List<Car>();

            if (File.Exists(file) && new FileInfo(file).Length > 0)
            {
                string json = File.ReadAllText(file);
                cars = JsonSerializer.Deserialize<List<Car>>(json);
            }

            return cars;
        }
        public List<Car> ReadCarsFromXml(string fileName, string schemaFile)
        {
            fileName = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, fileName);
            schemaFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, schemaFile);
            List<Car> cars = new List<Car>();

            if (!File.Exists(fileName))
            {
                return null;
            }

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add(null, schemaFile);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Car>), new XmlRootAttribute("Cars") { Namespace = "http://www.w3.org/2001/XMLSchema" });

            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                cars = (List<Car>)serializer.Deserialize(fileStream);
            }
            return cars;
        }

        public List<Car> SaveCars(string filename, List<Car> cars)
        {
            string file = "";
            if (Directory.GetCurrentDirectory().Contains(@"\bin\Debug"))
            {
                file = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName).FullName, filename);
            }
            else
            {
                file = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, filename);
            }


            string json = JsonSerializer.Serialize(cars, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(file, json);

            return cars;
        }




    }
}

