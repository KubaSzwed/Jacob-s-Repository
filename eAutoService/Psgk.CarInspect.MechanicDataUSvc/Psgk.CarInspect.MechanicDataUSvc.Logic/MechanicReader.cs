namespace Psgk.CarInspect.MechanicDataUSvc.Logic
{
    using Psgk.CarInspect.MechanicDataUSvc.Model;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Xml.Serialization;
    using System.Xml;

    public class MechanicReader
    {
        public List<Mechanic> ReadMechanics(string filename)
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

            List<Mechanic> mechanics = new List<Mechanic>();

            if (File.Exists(file) && new FileInfo(file).Length > 0)
            {
                string json = File.ReadAllText(file);
                mechanics = JsonSerializer.Deserialize<List<Mechanic>>(json);
            }

            return mechanics;
        }
        public List<Mechanic> WriteInspections(string filename, Mechanic mechanic)
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

            List<Mechanic> mechanics = ReadMechanics(filename);

            mechanics.Add(mechanic);

            string json = JsonSerializer.Serialize(mechanics, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(file, json);

            return mechanics;
        }

        public List<Mechanic> ReadMechanicsFromXml(string fileName, string schemaFile)
        {
            fileName = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, fileName);
            schemaFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, schemaFile);
            List<Mechanic> mechanics = new List<Mechanic>();

            if (!File.Exists(fileName))
            {
                return null;
            }

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add(null, schemaFile);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Mechanic>), new XmlRootAttribute("DataMechanics") { Namespace = "http://www.w3.org/2001/XMLSchema" });

            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                mechanics = (List<Mechanic>)serializer.Deserialize(fileStream);
            }
            return mechanics;
        }





        public void DeleteMechanics(string filename, int id)
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

            List<Mechanic> mechanics = ReadMechanics(filename);

            mechanics.RemoveAll(i => i.Id == id);

            string json = JsonSerializer.Serialize(mechanics, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(file, json);
        }
    }
}







