using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psgk.CarInspect.MechanicDataUSvc.Model
{
    public class Mechanic
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get; set; }
        public string WorkPlace { get; set; }
        public Mechanic(string fName, string fSurname, int fId, string fWorkPlace)
        {
            Name = fName;
            Surname = fSurname;
            Id = fId;
            WorkPlace = fWorkPlace;
        }
        public Mechanic() { }

        public override string ToString()
        {
            return "{ Name:" + Name + " Surname:" + Surname + ", Id:" + Id + "WorkPlace: " + WorkPlace + "}";
        }
    }
}


