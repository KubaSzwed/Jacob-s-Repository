

namespace Psgk.CarInspect.ServiceDataUSvc.WebService.Mapper
{
    using Psgk.CarInspect.ServiceDataUSvc.Model;
    using Psgk.CarInspect.ServiceDataUSvc.RestModel;

    public static class Mapper
    {
        public static ServiceDto Map (this Service service)
        {
            if(service == null)
            {
                return null;
            }
            return new ServiceDto
            {
                id = service.id,
                name = service.name,                
                price = service.price,
                carid = service.carid,
            };

        }


    }
}


