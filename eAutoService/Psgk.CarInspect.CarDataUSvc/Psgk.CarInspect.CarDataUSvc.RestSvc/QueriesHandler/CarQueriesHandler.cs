namespace Psgk.CarInspect.CarDataUSvc.RestSvc.QueriesHandler
{

    using Psgk.CarInspect.CarDataUSvc.Logic;
    using Psgk.CarInspect.CarDataUSvc.RestModel;
    using Psgk.CarInspect.CarDataUSvc.RestSvc1.Mapper;
    using Psgk.CarInspect.CarDataUSvc.Model;


    public class CarQueriesHandler : ICarQueriesHandler
    {
        private readonly ICars cars;

        public CarQueriesHandler()
        {
            this.cars = new Cars();
        }
        public IEnumerable<CarDto> FindByBrand(string Brand)
        {
            return cars.FindByBrand(Brand).Select(x => x.Map());
        }

        public IEnumerable<CarDto> FindByRegistrationNumber(string registrationNumber)
        {
            return cars.FindByRegistrationNumber(registrationNumber).Select(x => x.Map());
        }

        public IEnumerable<CarDto> FindByModel(string Model)
        {
            return cars.FindByModel(Model).Select(x => x.Map());
        }
        public void AddCar(string Brand, string Model, string registrationNumber,int ownerId, int mechanicId)
        {
            cars.AddCar(Brand, Model, registrationNumber, ownerId, mechanicId);
        }
        public void DeleteCar(string registrationNumber)
        {
            cars.DeleteCar(registrationNumber);
        }
        public IEnumerable<Car> GetCars()
        {
            return cars.GetCars();
        }

    }
}
