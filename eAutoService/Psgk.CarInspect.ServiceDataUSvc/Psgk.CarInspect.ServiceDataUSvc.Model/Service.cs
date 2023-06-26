using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Psgk.CarInspect.ServiceDataUSvc.Model
{
    public class Service
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int[] carid { get; set; }


        public Service(int Id, string Name, int Price, int[] carId)
        {
            id = Id;
            name = Name;
            price = Price;
            carid = carId;
        }

        public Service()
        {
        }
        public override string ToString()
        {
            return "{ Id:" + id + ", Name:" + name + "Price: " + price + "carId" + carid +"}";
        }


    }
}
