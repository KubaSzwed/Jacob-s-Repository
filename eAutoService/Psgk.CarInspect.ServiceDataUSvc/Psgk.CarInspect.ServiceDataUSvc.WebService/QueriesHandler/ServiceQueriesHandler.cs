

namespace Psgk.CarInspect.ServiceDataUSvc.WebService.QueriesHandler
{
    using Psgk.CarInspect.ServiceDataUSvc.Model;
    using Psgk.CarInspect.ServiceDataUSvc.Logic;
    using Psgk.CarInspect.ServiceDataUSvc.RestModel;
    using Psgk.CarInspect.ServiceDataUSvc.WebService.Mapper;
    using System.Collections.Generic;

    public class ServiceQueriesHandler : IServiceQueriesHandler
    {
        private readonly IServices services;
        public ServiceQueriesHandler()
        {
            this.services = new Servicees();        
        }

        public IEnumerable<ServiceDto> DisplayServices()
        {
            return services.DisplayServices().Select(x => x.Map());
        }
        public IEnumerable<ServiceDto> FindById(int Id)
        {
            return services.FindById(Id).Select(x => x.Map());
        }

        public void AddService(int Id, string Name, int Price, int[] carid)
        {
            services.AddService(Id, Name, Price, carid);
        }
        public void DeleteService(int Id)
        {
            services.DeleteService(Id);
        }
       

    }


}







