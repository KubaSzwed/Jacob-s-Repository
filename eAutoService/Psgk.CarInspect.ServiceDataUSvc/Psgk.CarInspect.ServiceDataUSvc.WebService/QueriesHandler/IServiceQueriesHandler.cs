
namespace Psgk.CarInspect.ServiceDataUSvc.WebService.QueriesHandler
{
    using Psgk.CarInspect.ServiceDataUSvc.RestModel;
    using Psgk.CarInspect.ServiceDataUSvc.Model;
    using System.Collections.Generic;

    public interface IServiceQueriesHandler
    {
        public IEnumerable<ServiceDto> DisplayServices();
        public IEnumerable<ServiceDto> FindById(int Id);

        public void AddService(int Id, string Name, int Price, int[] carid);

        public void DeleteService(int Id);




    }
}

