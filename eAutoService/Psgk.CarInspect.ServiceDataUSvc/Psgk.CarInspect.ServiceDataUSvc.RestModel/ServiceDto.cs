using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psgk.CarInspect.ServiceDataUSvc.RestModel
{
    public class ServiceDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }

        public int[] carid { get; set; }
        

        public override string ToString()
        {
            return "{ Id:" + id + ", Name:" + name + "Price: " + price + "carId" + carid + "}";
        }

    }
}
