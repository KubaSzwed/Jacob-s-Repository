using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psgk.CarInspect.ClientAppService.RestModel
{ public  class ServiceData
    {


        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }


        public ServiceData()
        {
        }

        public ServiceData(int Id, string Name, int Price)
        {
            id = Id;
            name = Name;
            price = Price;
        }
    }
   
}
