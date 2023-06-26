using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psgk.CarInspect.ServiceDataUSvc.Logic
{
    using Psgk.CarInspect.ServiceDataUSvc.Model;
    using Psgk.CarInspect.ServiceDataUSvc.Logic;
    using System.Collections.Generic;
    using System.Linq;
    using Psgk.CarInspect.ServiceDataUSvc.Logic;

    public class Servicees : IServices
    {
        private const string servicesFilename = "services.json";
        private static readonly object serviceLock = new object();
        private static List<Service> servicesList = new List<Service>();

        static Servicees()
        {
            lock (Servicees.serviceLock)
            {
                ServiceReader serviceReader = new ServiceReader();
                List<Service> services = serviceReader.ReadServices(servicesFilename);
                servicesList = services;
            }
        }

        public IEnumerable<Service> DisplayServices()
        {
            lock (Servicees.serviceLock)
            {
                ServiceReader serviceReader = new ServiceReader();
                List<Service> services = serviceReader.ReadServices(servicesFilename);
                servicesList = services;
                return servicesList;
            }
        }
        public IEnumerable<Service> FindById(int Id)
        {
            lock (Servicees.serviceLock)
            {
                ServiceReader serviceReader = new ServiceReader();
                List<Service> services = serviceReader.ReadServices(servicesFilename);
                List<Service> list = new List<Service> { };

                foreach (Service service in services)
                {
                    if (service.id == Id)
                    {
                        list.Add(service);
                    }
                }

                return list;
            }
        }

        public void AddService(int Id, string Name, int Price, int[] carid)
        {
            lock (Servicees.serviceLock)
            {
                ServiceReader serviceReader = new ServiceReader();
                List<Service> servicess = serviceReader.ReadServices(servicesFilename);
                serviceReader.WriteInspections(servicesFilename, new Service(Id,Name,Price, carid));

            }
        }

        public void DeleteService(int Id)
        {
            lock (Servicees.serviceLock)
            {
                ServiceReader serviceReader = new ServiceReader();
                serviceReader.DeleteServices(servicesFilename, Id);
            }

        }
        static void Main()

        {

        }


    }
}