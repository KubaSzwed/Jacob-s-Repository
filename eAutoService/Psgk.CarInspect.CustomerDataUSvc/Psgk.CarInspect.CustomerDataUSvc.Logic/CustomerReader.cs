namespace Psgk.CarInspect.CustomerDataUSvc.Logic
{

    using Psgk.CarInspect.CustomerDataUSvc.Model;
    using System.Collections.Generic;
    using System.Text.Json;


    public class CustomerReader
    {
        public List<Customer> ReadCustomers(string filename)
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

            List<Customer> customers = new List<Customer>();

            if (File.Exists(file) && new FileInfo(file).Length > 0)
            {
                string json = File.ReadAllText(file);
                customers = JsonSerializer.Deserialize<List<Customer>>(json);
            }

            return customers;
        }
        public void DeleteCustomers(string filename, int id)
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

            List<Customer> customers = ReadCustomers(filename);

            customers.RemoveAll(i => i.Id == id);

            string json = JsonSerializer.Serialize(customers, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(file, json);
        }

        public List<Customer> SaveCustomers(string filename, Customer customer)
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

            List<Customer> customers = ReadCustomers(filename);

            customers.Add(customer);

            string json = JsonSerializer.Serialize(customers, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(file, json);

            return customers;
        }




    }
}

