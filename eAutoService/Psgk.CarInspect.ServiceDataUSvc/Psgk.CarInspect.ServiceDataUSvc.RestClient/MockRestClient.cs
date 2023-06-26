using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psgk.CarInspect.ServiceDataUSvc.RestClient
{
    using System;
    using System.Threading.Tasks;
    using Psgk.CarInspect.ServiceDataUSvc.RestModel;
    using System.Xml.Linq;

    public class MockRestClient : IRestClient
    {
        private ServiceDto[] serviceDtos;
        public string[] nameList = new string[] { "n1", "n2", "n3", "n4" };
        


        public MockRestClient()
        {
            serviceDtos = new ServiceDto[4];

            for (int i = 0; i < 4; i++)
            {
                serviceDtos[i] = (ServiceDto)Activator.CreateInstance(typeof(ServiceDto));
                serviceDtos[i].id = i;
                serviceDtos[i].name = nameList[i];
                serviceDtos[i].price = i + 100;
              

            }
        }

        public async Task AddService(int Id, string Name, int Price, int[] CarId)
        {
            ServiceDto service = new ServiceDto();        
            service.id = Id;
            service.name = Name;
            service.price = Price;
            service.carid = CarId;
            Array.Resize(ref serviceDtos, serviceDtos.Length + 1);
            serviceDtos[serviceDtos.Length - 1] = service;
        }

        public async Task DeleteService(int Id)
        {
            List<ServiceDto> servicesList = serviceDtos.ToList();
            servicesList.RemoveAll(x => x.id == Id);
            serviceDtos = servicesList.ToArray();
        }

        public async Task<ServiceDto[]> DisplayServices()
        {
            return serviceDtos;
        }


        public async Task<ServiceDto[]> FindById(int Id)
        {
            List<ServiceDto> services = new List<ServiceDto>();
            foreach (ServiceDto service in serviceDtos)
            {
                if (service.id == Id)
                {
                    services.Add(service);
                }
            }
            return services.ToArray();

        }

    }
}

