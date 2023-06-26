using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psgk.CarInspect.ClientAppService.Model
{
    public class ServiceDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }

        public int[] carid { get; set; }

        public ServiceDto()
        {
        }

        public ServiceDto(int Id, string Name, int Price)
        {
            id = Id;
            name = Name;
            price = Price;
        }
    }
}
