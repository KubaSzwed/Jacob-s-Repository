
using Psgk.CarInspect.ServiceDataUSvc.RestClient;
using Psgk.CarInspect.ServiceDataUSvc.RestModel;



RestClient restClient = new RestClient();

Task<ServiceDto[]> task = restClient.DisplayServices();
ServiceDto[] services = task.Result;

foreach (ServiceDto service in services)
{
    Console.WriteLine(service);
}

Console.WriteLine("-----------------------------");

Task<ServiceDto[]> task1 = restClient.FindById(1);
ServiceDto[] services1 = task1.Result;

foreach (ServiceDto service1 in services1)
{
    Console.WriteLine(service1);
}

Console.WriteLine("-----------------------------");

int[] carsids = {0, 1, 2};
Task task2 = restClient.AddService(5,"Tyre", 222, carsids);

Task<ServiceDto[]> task3 = restClient.DisplayServices();
ServiceDto[] services2 = task3.Result;

foreach (ServiceDto serrvice2 in services2)
{
    Console.WriteLine(serrvice2);
}

Task task4 = restClient.AddService(4, "Tyre", 222, carsids);


Task<ServiceDto[]> task5 = restClient.DisplayServices();
ServiceDto[] services3 = task5.Result;
foreach (ServiceDto serrvice3 in services3)
{
    Console.WriteLine(serrvice3);
}


