

namespace Psgk.CarInspect.CarDataUSvc.Model
{

    public interface ICars
    {
        IEnumerable<Car> FindByBrand(string Brand);

        IEnumerable<Car> FindByRegistrationNumber(string registrationNumber);

        IEnumerable<Car> FindByModel(string Model);

        public void AddCar(string Brand, string Model, string registrationNumber, int ownerId, int mechanicId);

        public void DeleteCar(string registrationNumber);

        public IEnumerable<Car> GetCars();










    }
}
