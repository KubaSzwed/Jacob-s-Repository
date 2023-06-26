namespace Psgk.CarInspect.CustomerDataUSvc.RestSvc.QueriesHandler
{
    
    using Psgk.CarInspect.CustomerDataUSvc.Logic;
    using Psgk.CarInspect.CustomerDataUSvc.RestModel;
    using Psgk.CarInspect.CustomerDataUSvc.RestSvc.Mapper;
    using Psgk.CarInspect.CustomerDataUSvc.Model;
    public class CustomerQueriesHandler : ICustomerQueriesHandler
    {
        private readonly ICustomers Customers;

        public CustomerQueriesHandler()
        {
            this.Customers = new Customers();
        }
        public IEnumerable<CustomerDto> FindByName(string Name)
        {
            return Customers.FindByName(Name).Select(x => x.Map());
        }

        public IEnumerable<CustomerDto> FindById(int CustomerId)
        {
            return Customers.FindById(CustomerId).Select(x => x.Map());
        }

        public void AddCustomer(int Id, string Name, string Address, string Phone, string Email)
        {
            Customers.AddCustomer(Id, Name, Address, Phone, Email);
        }
        public void DeleteCustomer(int CustomerId )
        {
            Customers.DeleteCustomer(CustomerId);
        }
        public IEnumerable<CustomerDto> DisplayCustomers()
        {
            return Customers.DisplayCustomers().Select(x => x.Map());
        }

    }
}
