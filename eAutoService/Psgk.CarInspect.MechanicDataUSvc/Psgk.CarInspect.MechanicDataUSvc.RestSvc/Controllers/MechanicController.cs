

namespace Psgk.CarInspect.MechanicDataUSvc.WebService.Controllers
    {
    using Microsoft.AspNetCore.Mvc;
    using Psgk.CarInspect.MechanicDataUSvc.WebService.QueriesHandler;
    using Psgk.CarInspect.MechanicDataUSvc.RestModel;

    [ApiController]
    [Route("[controller]")]
    public class MechanicController : ControllerBase
    {
        private readonly ILogger<MechanicController> _logger;
        private readonly IMechanicQueriesHandler _queriesHandler;

        public MechanicController(ILogger<MechanicController> logger)
        {
            _logger = logger;
            _queriesHandler = new MechanicQueriesHandler();
        }

        [HttpGet]
        [Route("FindMechanicByName/{Name}")]
        public IEnumerable<MechanicDto> FindByName(string Name)
        {
            return _queriesHandler.FindByName(Name);
        }

        [HttpGet]
        [Route("FindMechanicBySurname/{Surname}")]
        public IEnumerable<MechanicDto> FindBySurname(string Surname)
        {
            return _queriesHandler.FindBySurname(Surname);
        }

        [HttpGet]
        [Route("FindMechanicByWorkPlace/{WorkPlace}")]
        public IEnumerable<MechanicDto> FindByWorkPlace(string WorkPlace)
        {
            return _queriesHandler.FindByWorkPlace(WorkPlace);
        }

        [HttpGet]
        [Route("DisplayAllMechanics")]
        public IEnumerable<MechanicDto> DisplayMechanics()
        {
            return _queriesHandler.DisplayMechanics();
        }

        [HttpPost]
        [Route("AddMechanic/{Name}/{Surname}/{WorkPlace}")]
        public void AddMechanic(string Name, string Surname, string WorkPlace)
        {
            _queriesHandler.AddMechanic(Name, Surname, WorkPlace);
        }

        [HttpPost]
        [Route("DeleteMechanic/{Id}")]
        public void DeleteMechanic(int Id)
        {
            _queriesHandler.DeleteMechanic(Id);
        }

        
    }
}




