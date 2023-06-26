
using Psgk.CarInspect.MechanicDataUSvc.Model;
using Psgk.CarInspect.MechanicDataUSvc.RestClient;
using Psgk.CarInspect.MechanicDataUSvc.RestModel;



RestClient restClient = new RestClient();

Task<MechanicDto[]> task = restClient.DisplayMechanics();
MechanicDto[] mechanics = task.Result;
foreach (MechanicDto mechanic in mechanics)
{
    Console.WriteLine(mechanic);
}

Console.WriteLine("-----------------------------------------");

Console.WriteLine("We are searching for Mechanics named John");

Task task1 = restClient.AddMechanic("James", "Lookman", "ManchesterCar");
Task<MechanicDto[]> task2 = restClient.FindByName("John");
MechanicDto[] mechanics2 = task2.Result;

foreach (MechanicDto mechanic2 in mechanics2)
{
    Console.WriteLine(mechanic2);
}
Console.WriteLine("-----------------------------------------");


Console.WriteLine("Just now we added a new mechanic");

Task<MechanicDto[]> task3 = restClient.DisplayMechanics();
MechanicDto[] mechanics3 = task3.Result;
foreach (MechanicDto mechanic3 in mechanics3)
{
    Console.WriteLine(mechanic3);
}

Console.WriteLine("-----------------------------------------");

Console.WriteLine("Now we delete one Mechanic with the highest ID");
Task task5 = restClient.DeleteMechanic(mechanics.Length + 1);

Task<MechanicDto[]> task4 = restClient.FindBySurname("Lookman");
MechanicDto[] mechanics4 = task4.Result;

foreach (MechanicDto mechanic4 in mechanics4)
{
    Console.WriteLine(mechanic4);
}

Task<MechanicDto[]> task6 = restClient.DisplayMechanics();
MechanicDto[] mechanics6 = task6.Result;

foreach (MechanicDto mechanic6 in mechanics6)
{
    Console.WriteLine(mechanic6);
}

Console.WriteLine("-----------------------------------------");





