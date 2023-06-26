using Psgk.CarInspect.ClientAppService.Model;
using Psgk.CarInspect.ClientAppService.RestModel;

namespace Psgk.CarInspect.ClientAppService.Rest
{
    public class DataConverter { 
    public static CustomersCar ConvertToCustomersCar(CarDto car)
    {
        return new CustomersCar(car.id, car.brand, car.model, car.registrationNumber);
    }

    public static ServiceData ConvertToServiceData(ServiceDto service) 
        {
            return new ServiceData(service.id, service.name, service.price);
        }

    }




}
