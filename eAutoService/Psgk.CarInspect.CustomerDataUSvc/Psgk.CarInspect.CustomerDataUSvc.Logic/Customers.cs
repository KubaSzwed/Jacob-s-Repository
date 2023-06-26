namespace Psgk.CarInspect.CustomerDataUSvc.Logic
{

    using System.Collections.Generic;
    using Psgk.CarInspect.CustomerDataUSvc.Model;

    public class Customers : ICustomers
    {
        private const string customersFilename = "Customers.json";
        private static readonly object customerLock = new object();
        private static List<Customer> customersList = new List<Customer>();


        Customer Customer = new Customer();
        static Customers()
        {
            lock (Customers.customerLock)
            {
                CustomerReader customerReader = new CustomerReader();
                List<Customer> customers = customerReader.ReadCustomers(customersFilename);
                customersList = customers;

            }
        }

        public IEnumerable<Customer> DisplayCustomers()
        {
            lock (Customers.customerLock)
            {
                CustomerReader customerReader = new CustomerReader();
                List<Customer> customers = customerReader.ReadCustomers(customersFilename);
                customersList = customers;
                return customersList;
            }
        }

        public IEnumerable<Customer> FindByName(string Name)
        {
            lock (Customers.customerLock)
            {
                CustomerReader CustomerReader = new CustomerReader();
                List<Customer> Customers = CustomerReader.ReadCustomers(customersFilename);
                List<Customer> list = new List<Customer> { };

                foreach (Customer Customer in Customers)
                {
                    if (Customer.Name.Contains(Name))
                    {
                        list.Add(Customer);
                    }
                }

                return list;
            }
        }

        public IEnumerable<Customer> FindById(int CustomerId)
        {
            lock (Customers.customerLock)
            {
                CustomerReader CustomerReader = new CustomerReader();
                List<Customer> Customers = CustomerReader.ReadCustomers(customersFilename);
                List<Customer> list = new List<Customer> { };

                foreach (Customer Customer in Customers)
                {
                    if (Customer.Id == CustomerId)
                    {
                        list.Add(Customer);
                    }
                }

                return list;
            }
        }


        public void AddCustomer(int Id, string Name, string Address, string Phone, string Email)
        {
            lock (Customers.customerLock)
            {
                CustomerReader CustomerReader = new CustomerReader();
                List<Customer> Customers = CustomerReader.ReadCustomers(customersFilename);
                CustomerReader.SaveCustomers(customersFilename, new Customer(Id,Name,Address,Phone,Email));
            }
        }

        public void DeleteCustomer(int Id )
        {
            lock (Customers.customerLock)
            {
                CustomerReader CustomerReader = new CustomerReader();
                CustomerReader.DeleteCustomers(customersFilename, Id);
            }


        }

        static void Main()

        {

        }


    }
}
