using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psgk.CarInspect.ClientAppService.RestModel
{
    public class CustomersCar
    {
        public int id { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string registrationNumber { get; set; }

        public CustomersCar(int id, string brand, string model, string registrationNumber) { 
            this.id = id;
                
            this.brand = brand;
                
            this.model = model;
                
            this.registrationNumber = registrationNumber;
            
        
        
        }


    }
}
