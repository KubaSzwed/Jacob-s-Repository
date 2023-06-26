using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psgk.CarInspect.ClientAppService.Model
{
    public class CarDto
    {
        public int id { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string registrationNumber { get; set; }
        public int ownerId { get; set; }
        public int mechanicId { get; set; }



        public override string ToString()
        {
            return "{Id:" + id + ", Brand:" + brand + ", Model:" + model + ", RegistrationNumber:" + registrationNumber + ", Owner id:" + ownerId + ", Mechanic id:" + mechanicId + "}";
        }
    }


}
