namespace Psgk.CarInspect.CarDataUSvc.RestSvc.QueriesHandler
{
    using Psgk.CarInspect.CarDataUSvc.Model;
    using Psgk.CarInspect.CarDataUSvc.RestModel;
    public interface ICarQueriesHandler
    {
        IEnumerable<CarDto> FindByBrand(string Brand);

        IEnumerable<CarDto> FindByRegistrationNumber(string registrationNumber);

        IEnumerable<CarDto> FindByModel(string Model);

        public void AddCar(string Brand, string Model, string registrationNumber, int ownerId, int mechanicId);

        public void DeleteCar(string registrationNumber);

        public IEnumerable<Car> GetCars();
    }
}
