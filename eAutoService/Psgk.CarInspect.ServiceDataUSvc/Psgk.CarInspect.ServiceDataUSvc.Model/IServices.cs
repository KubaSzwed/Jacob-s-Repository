using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psgk.CarInspect.ServiceDataUSvc.Model
{
    public interface IServices
    {
        public IEnumerable<Service> DisplayServices();
        public IEnumerable<Service> FindById(int Id);

        public void AddService(int Id, string Name, int Price, int[] carid);

        public void DeleteService(int Id);



    }
}
