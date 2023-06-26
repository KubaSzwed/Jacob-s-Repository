namespace Psgk.CarInspect.ServiceDataUSvc.WebService.Controllers
    {
    using Microsoft.AspNetCore.Mvc;
    using Psgk.CarInspect.ServiceDataUSvc.WebService.QueriesHandler;
    using Psgk.CarInspect.ServiceDataUSvc.RestModel;

    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly ILogger<ServiceController> _logger;
        private readonly IServiceQueriesHandler _queriesHandler;

        public ServiceController(ILogger<ServiceController> logger)
        {
            _logger = logger;
            _queriesHandler = new ServiceQueriesHandler();
        }
    
        [HttpGet("GetServiceById/{Id}")]
        public IEnumerable<ServiceDto> FindById(int Id)
        {
            return _queriesHandler.FindById(Id);
        }

        [HttpGet("GetAllServices")]
        public IEnumerable<ServiceDto> DisplayServices()
        {
            return _queriesHandler.DisplayServices();
        }



        [HttpPost("AddService/")]
        public void AddService(int Id, string Name, int Price, int[] CarId)
        {
            _queriesHandler.AddService(Id, Name, Price, CarId);
        }

        [HttpPost("DeleteService/{Id}")]
        public void DeleteService(int Id)
        {
            _queriesHandler.DeleteService(Id);
        }

        
    }
}




