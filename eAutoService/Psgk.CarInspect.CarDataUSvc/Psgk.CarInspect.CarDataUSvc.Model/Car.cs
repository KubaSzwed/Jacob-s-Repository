namespace Psgk.CarInspect.CarDataUSvc.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }

        public int ownerId { get; set; }
        public int mechanicId { get; set; }

    

        public Car(int fId, string fBrand, string fModel, string fRegistrationNumber, int fownerId, int fmechanicId)
        {
            Id = fId;
            Brand = fBrand;
            Model = fModel;
            RegistrationNumber = fRegistrationNumber;
            ownerId = fownerId;
            mechanicId = fmechanicId;
           
        }

        public Car()
        {
        }
        public override string ToString()
        {
            return "{Id:" + Id + ", Brand:" + Brand + ", Model:" + Model + ", RegistrationNumber:" + RegistrationNumber + ", Owner id:" + ownerId + ", Mechanic id:" + mechanicId + "}";
        }
    }
}