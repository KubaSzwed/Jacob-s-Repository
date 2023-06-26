namespace Psgk.CarInspect.CustomerDataUSvc.RestSvc.QueriesHandler
{
    using Psgk.CarInspect.CustomerDataUSvc.RestModel;
    using System.Collections.Generic;

    public interface ICustomerQueriesHandler
    {
        IEnumerable<CustomerDto> FindByName(string Name);

        IEnumerable<CustomerDto> FindById(int CustomerId);

        public void AddCustomer(int Id, string Name, string Address, string Phone, string Email);

        public void DeleteCustomer(int CustomerId);

        IEnumerable<CustomerDto> DisplayCustomers();
    }
}
