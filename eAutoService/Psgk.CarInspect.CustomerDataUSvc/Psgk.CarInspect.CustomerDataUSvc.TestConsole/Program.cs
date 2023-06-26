
using Psgk.CarInspect.CustomerDataUSvc.RestClient;
using Psgk.CarInspect.CustomerDataUSvc.RestModel;



RestClient restClient = new RestClient();

Task<CustomerDto[]> task = restClient.DisplayCustomers();
CustomerDto[] customers = task.Result;

foreach (CustomerDto customer in customers)
{
    Console.WriteLine(customer);
}

Console.WriteLine("-----------------------------");

Task<CustomerDto[]> task1 = restClient.FindCustomerByName("John Doe");
CustomerDto[] customers1 = task1.Result;

foreach (CustomerDto customer1 in customers1)
{
    Console.WriteLine(customer1);
}

Console.WriteLine("-----------------------------");


Task<CustomerDto[]> task2 = restClient.FindCustomerById(1);
CustomerDto[] customers2 = task2.Result;

foreach (CustomerDto customer2 in customers2)
{
    Console.WriteLine(customer2);
}

Console.WriteLine("-----------------------------");


Task task3 = restClient.AddCustomer(11, "Johny Drinkwater", "Wall Street", "611728101", "london@gmail.com");


Task<CustomerDto[]> task5 = restClient.FindCustomerById(11);
CustomerDto[] customers5 = task5.Result;

Task<CustomerDto[]> task4 = restClient.DisplayCustomers();
CustomerDto[] customers4 = task4.Result;

foreach (CustomerDto customer4 in customers4)
{
    Console.WriteLine(customer4);
}