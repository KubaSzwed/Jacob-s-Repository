namespace Psgk.CarInspect.CustomerDataUSvc.RestSvc.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Psgk.CarInspect.CustomerDataUSvc.RestSvc.QueriesHandler;
    using Psgk.CarInspect.CustomerDataUSvc.RestModel;

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerQueriesHandler _queriesHandler;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
            _queriesHandler = new CustomerQueriesHandler();
        }

        [HttpGet("DisplayAllCustomer")]
        public IEnumerable<CustomerDto> DisplayCustomers()
        {
            return _queriesHandler.DisplayCustomers();
        }

        [HttpGet("GetCustomerById")]
        public IEnumerable<CustomerDto> FindById(int id)
        {
            return _queriesHandler.FindById(id);
        }

        [HttpGet("GetCustomerByName")]
        public IEnumerable<CustomerDto> FindByName(string name)
        {
            return _queriesHandler.FindByName(name);
        }

        [HttpPost("AddCustomer")]
        public void AddCustomer(int Id, string Name, string Address, string Phone, string Email)
        {
            _queriesHandler.AddCustomer(Id, Name, Address, Phone, Email);
        }


        [HttpDelete("DeleteCustomer")]
        public void DeleteCustomer(int CustomerId)
        {
            _queriesHandler.DeleteCustomer(CustomerId);
        }
    }
}
