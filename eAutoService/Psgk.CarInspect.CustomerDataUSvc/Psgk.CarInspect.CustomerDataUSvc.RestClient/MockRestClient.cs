using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psgk.CarInspect.CustomerDataUSvc.RestClient
{

    using System;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using Psgk.CarInspect.CustomerDataUSvc.RestModel;

    internal class MockRestClient : IRestClient
    {
        private CustomerDto[] customerDtos;
        public string[] nameList = new string[] { "name1", "anme2", "name3", "named4" };
        public string[] addressList = new string[] { "a1", "a2", "a3", "a4" };
        public string[] phoneList = new string[] { "1234", "2223143ce2", "13452", "145514" };
        public string[] emailList = new string[] { "a1", "a2", "a3", "a4" };


        public MockRestClient()
        {
            customerDtos = new CustomerDto[4];

            for (int i = 0; i < 4; i++)
            {
                customerDtos[i] = (CustomerDto)Activator.CreateInstance(typeof(CustomerDto));
                customerDtos[i].id = i;
                customerDtos[i].name = nameList[i];
                customerDtos[i].address = addressList[i];
                customerDtos[i].phone = phoneList[i];
                customerDtos[i].email = emailList[i];

            }
        }

        public async Task AddCustomer(int Id, string Name, string Address, string Phone, string Email)
        {
            CustomerDto customer = new CustomerDto();
            customer.id = Id;
            customer.name = Name;
            customer.address = Address;
            customer.phone = Phone;
            customer.email = Email;
            Array.Resize(ref customerDtos, customerDtos.Length + 1);
            customerDtos[customerDtos.Length - 1] = customer;
        }
        public async Task DeleteCustomer(int Id)
        {
            List<CustomerDto> customersList = customerDtos.ToList();
            customersList.RemoveAll(x => x.id == Id);
            customerDtos = customersList.ToArray();
        }

        public async Task<CustomerDto[]> DisplayCustomers()
        {
            return customerDtos;
        }

        public async Task<CustomerDto[]> FindByName(string Name)
        {
            List<CustomerDto> customers = new List<CustomerDto>();
            foreach (CustomerDto customer in customerDtos)
            {
                if (customer.name == Name)
                {
                    customers.Add(customer);
                }
            }
            return customers.ToArray();
        }

        public async Task<CustomerDto[]> FindById(int Id)
        {
            List<CustomerDto> customers = new List<CustomerDto>();
            foreach (CustomerDto customer in customerDtos)
            {
                if (customer.id == Id)
                {
                    customers.Add(customer);
                }
            }
            return customers.ToArray();
        }


    }
}


