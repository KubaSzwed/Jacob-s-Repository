namespace Psgk.CarInspect.CustomerDataUSvc.Model
{
   
    public interface ICustomers
    {
        IEnumerable<Customer> FindByName(string Name);

        IEnumerable<Customer> FindById(int CustomerId);
        IEnumerable<Customer> DisplayCustomers();

        public void AddCustomer(int Id, string Name, string Address, string Phone, string Email);

        public void DeleteCustomer(int Id);



}
}
