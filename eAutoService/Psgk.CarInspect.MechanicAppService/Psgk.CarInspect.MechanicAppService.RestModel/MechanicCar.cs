namespace Psgk.CarInspect.MechanicAppService.RestModel
{
    public class MechanicCar
    {
        public int id { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string registrationNumber { get; set; }

        public MechanicCar(int id, string brand, string model, string registrationNumber)
        {
            this.id = id;

            this.brand = brand;

            this.model = model;

            this.registrationNumber = registrationNumber;



        }
    }
}
