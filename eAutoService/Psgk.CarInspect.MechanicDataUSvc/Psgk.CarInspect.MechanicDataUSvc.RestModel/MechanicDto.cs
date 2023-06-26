
namespace Psgk.CarInspect.MechanicDataUSvc.RestModel
{
    public class MechanicDto
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int id { get; set; }
        public string workPlace { get; set; }


        public override string ToString()
        {
            return "{ Name:" + name + " Surname:" + surname + ", Id:" + id + "WorkPlace: " + workPlace + "}";
        }

    }


}
