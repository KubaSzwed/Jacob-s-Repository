using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Psgk.CarInspect.ClientAppService.Model;
using Psgk.CarInspect.ClientAppService.Rest;
using Psgk.CarInspect.ClientAppService.RestModel;

namespace Ssga.CarInspect.ClientAppService.Rest
{
    [ApiController]
    [Route("[controller]")]
    public class ClientAppServiceController : ControllerBase
    {
        private readonly ILogger<ClientAppServiceController> logger;

        private RestClient restClient;
        private ServiceClient serviceClient;
        private CarClient carClient;
        

        public ClientAppServiceController(ILogger<ClientAppServiceController> logger)
        {
            this.logger = logger;
            restClient = new RestClient();
            serviceClient = new ServiceClient();
            carClient = new CarClient();

        }

        [HttpGet]
        [Route("FindAllOwnedCars/{clientID}")]
        public CustomersCar[] DisplayCustomerCars(int clientID)
        {
            return carClient.GetCustomerCar(clientID).Result;

        }

        [HttpGet]
        [Route("CustomerInfo/{clientID}")]
        public CustomerDto[] GetCustomerInfo(int clientID)
        {
            return restClient.FindCustomerById(clientID).Result;

        }

        [HttpGet]
        [Route("ServiceInfo/{id}")]
        public ServiceData[] GetServices(int id)
        {


            ServiceDto[] services =  serviceClient.FindById(id).Result;
            List<ServiceData> serviceData = new List<ServiceData>();

            foreach (ServiceDto obj in services)
            {
                if (Array.IndexOf(obj.carid, id) >= 0)
                {


                    ServiceData serviceData1 = new ServiceData(obj.id, obj.name, obj.price);
                serviceData.Add(serviceData1);

                }

            }
            Console.WriteLine(serviceData);
            return serviceData.ToArray();
        }

        [HttpGet]
        [Route("ServiceInfo/AllService")]
        public ServiceData[] GetAllServices()
        {
            ServiceDto[] services = serviceClient.GetServices().Result;
            List<ServiceData> serviceData = new List<ServiceData>();

            foreach (ServiceDto obj in services)
            {

              
                    ServiceData serviceData1 = new ServiceData(obj.id, obj.name, obj.price);
                    serviceData.Add(serviceData1);
 
                

            }
            Console.WriteLine(serviceData);
            return serviceData.ToArray();
        }

        [HttpPost]
        [Route("ServiceInfo/ModifyCustomer")]
        public void ModifyCustomer(int id, string name, string address, string phone, string email)
        {
            restClient.DeleteCustomer(id);
            restClient.AddCustomer( id,  name,  address,  phone,  email);
        }




    }
}