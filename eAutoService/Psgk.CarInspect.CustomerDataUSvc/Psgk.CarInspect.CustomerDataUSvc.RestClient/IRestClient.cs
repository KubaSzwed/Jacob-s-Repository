

namespace Psgk.CarInspect.CustomerDataUSvc.RestClient
{

    using Psgk.CarInspect.CustomerDataUSvc.RestModel;
    internal interface IRestClient
    {
        Task<CustomerDto[]> FindByName(string Name);

        Task<CustomerDto[]> FindById(int Id);

        Task<CustomerDto[]> DisplayCustomers();

        Task AddCustomer(int Id, string Name, string Address, string Phone, string Email);

        Task DeleteCustomer(int Id);




    }
}
