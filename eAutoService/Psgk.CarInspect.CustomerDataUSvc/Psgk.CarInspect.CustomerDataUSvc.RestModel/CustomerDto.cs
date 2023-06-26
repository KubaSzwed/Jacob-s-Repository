using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace Psgk.CarInspect.CustomerDataUSvc.RestModel
{
    public class CustomerDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }


        public override string ToString()
        {
            return "{ Id:" + id + ", Name:" + name + ", Address:" + address + ", Phone: " + phone + ", Email: " + email + "}";
        }
    }
}