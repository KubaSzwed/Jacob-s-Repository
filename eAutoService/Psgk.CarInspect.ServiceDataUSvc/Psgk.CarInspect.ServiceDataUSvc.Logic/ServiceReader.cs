namespace Psgk.CarInspect.ServiceDataUSvc.Logic
{
    using Psgk.CarInspect.ServiceDataUSvc.Model;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Xml.Serialization;
    using System.Xml;

    public class ServiceReader
    {
        public List<Service> ReadServices(string filename)
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

            List<Service> services = new List<Service>();

            if (File.Exists(file) && new FileInfo(file).Length > 0)
            {
                string json = File.ReadAllText(file);
                services = JsonSerializer.Deserialize<List<Service>>(json);
            }

            return services;
        }

        public List<Service> ReadServicesFromXml(string fileName, string schemaFile)
        {
            fileName = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, fileName);
            schemaFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, schemaFile);
            List<Service> service = new List<Service>();

            if (!File.Exists(fileName))
            {
                return null;
            }

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add(null, schemaFile);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Service>), new XmlRootAttribute("Service") { Namespace = "http://www.w3.org/2001/XMLSchema" });

            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                service = (List<Service>)serializer.Deserialize(fileStream);
            }
            return service;
        }


        public List<Service> WriteInspections(string filename, Service service)
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

            List<Service> services = ReadServices(filename);

            services.Add(service);

            string json = JsonSerializer.Serialize(services, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(file, json);

            return services;
        }





        public void DeleteServices(string filename, int id)
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

            List<Service> services = ReadServices(filename);

            services.RemoveAll(i => i.id == id);

            string json = JsonSerializer.Serialize(services, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(file, json);
        }
    }
}







