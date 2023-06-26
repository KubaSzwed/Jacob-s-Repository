using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psgk.CarInspect.ServiceDataUSvc.RestClient
{
    using Psgk.CarInspect.ServiceDataUSvc.Model;
    using Psgk.CarInspect.ServiceDataUSvc.RestModel;

    public interface IRestClient
    {
        Task<ServiceDto[]> GetServices();
        Task<ServiceDto[]> FindById(int id);
        Task AddService(int Id, string Name, int Price, int[] CarId);

        Task DeleteService(int Id);



    }
}