using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Psgk.CarInspect.ClientAppService.Rest;
using Psgk.CarInspect.MechanicAppService.Model;
using Psgk.CarInspect.MechanicAppService.RestModel;

namespace Ssga.CarInspect.ClientAppService.Rest
{
    [ApiController]
    [Route("[controller]")]
    public class ClientAppServiceController : ControllerBase
    {
        private readonly ILogger<ClientAppServiceController> logger;

        private RestClient restClient;
        private MechanicClient mechanicClient;
        private ServiceClient serviceClient;
        private CarClient carClient;



        public ClientAppServiceController(ILogger<ClientAppServiceController> logger)
        {
            this.logger = logger;
            restClient = new RestClient();
            mechanicClient = new MechanicClient();
            serviceClient = new ServiceClient();
            carClient = new CarClient();    
            
        }

        [HttpGet]
        [Route("DisplayMechanics")]
        public MechanicDto[] DisplayMechanics()
        {
            return mechanicClient.DisplayMechanics().Result;

        }


        [HttpGet]
        [Route("FindMechanicByName/{name}")]
        public MechanicDto[] GetMechanicInfo(string name)
        {
            return mechanicClient.FindByName(name).Result;

        }


        [HttpGet]
        [Route("CustomerInfo/{clientID}")]
        public CustomerDto[] GetCustomerInfo(int clientID)
        {
            return restClient.FindCustomerById(clientID).Result;

        }



        [HttpGet]
        [Route("FindAllClientsCars/client/{clientID}")]
        public CustomersCar[] GetClientInfo(int clientID)
        {
            return carClient.GetCustomerCar(clientID).Result;

        }



        [HttpGet]
        [Route("ServiceInfo/All")]
        public ServiceDto[] GetAllServices()
        {


            return serviceClient.GetServices().Result;

        }


        [HttpGet]
        [Route("ServiceInfo/{id}")]
        public ServiceDto[] GetService(int id)
        {


            return serviceClient.FindById(id).Result;

        }


        [HttpPost]
        [Route("ServiceAdd/ModyfiService/")]
        public void EditService(int id, string name, int price, int[] carid)
        {


            serviceClient.DeleteService(id);
            serviceClient.AddService(id, name, price, carid);
            return;

        }

        [HttpPost]
        [Route("EditCustomer/")]
        public void ModifyCustomer(int id, string name, string address, string phone, string email)
        {
            restClient.DeleteCustomer(id);
            restClient.AddCustomer(id, name, address, phone, email);
        }






    }
}