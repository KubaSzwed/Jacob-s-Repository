namespace Psgk.CarInspect.CarDataUSvc.RestSvc.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Psgk.CarInspect.CarDataUSvc.RestSvc.QueriesHandler;
    using Psgk.CarInspect.CarDataUSvc.RestModel;
    using Psgk.CarInspect.CarDataUSvc.Model;
    

    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {

        private readonly ILogger<CarController> _logger;
        private readonly ICarQueriesHandler _queriesHandler;

        public CarController(ILogger<CarController> logger)
        {
            _logger = logger;
            _queriesHandler = new CarQueriesHandler();
        }

        [HttpGet]
        [Route("FindCarByRegistrationNumber/{registrationNumber}")]
        public IEnumerable<CarDto> FindByRegistrationNumber(string registrationNumber)
        {
            return _queriesHandler.FindByRegistrationNumber(registrationNumber);
        }

        [HttpGet]
        [Route("FindCarByBrand/{Brand}")]
        public IEnumerable<CarDto> FindByBrand(string Brand)
        {
            return _queriesHandler.FindByBrand(Brand);
        }

        [HttpGet]
        [Route("FindCarByModel/{Model}")]
        public IEnumerable<CarDto> FindByModel(string Model)
        {
            return _queriesHandler.FindByModel(Model);
        }

        [HttpPost]
        [Route("AddCar/{Brand}/{Model}/{registrationNumber}/{ownerId}/{MechanicId}")]
        public void AddCar(string Brand, string Model, string registrationNumber, int ownerId, int mechanicId)
        {
            _queriesHandler.AddCar(Brand, Model, registrationNumber, ownerId, mechanicId);
        }
        [HttpPost]
        [Route("DeleteCar/{registrationNumber}")]
        public void DeleteCar(string registrationNumber)
        {
            _queriesHandler.DeleteCar(registrationNumber);
        }

        [HttpGet("GetCars")]
        public IEnumerable<Car> GetCars()
        {
            return _queriesHandler.GetCars();
        }
    }
}
