namespace Psgk.CarInspect.CarDataUSvc.RestClient
{
    using Psgk.CarInspect.CarDataUSvc.RestModel;
    using System;
    using System.Threading.Tasks;

    public class MockRestClient : IRestClient
    {
        private CarDto[] carDtos;
        public string[] brandList = new string[] { "brand1", "brandw", "brand3", "brand4" };
        public string[] modelList = new string[] { "model1", "model2", "model3", "model4" };
        public string[] registrationList = new string[] { "registration1", "registration2", "registration3", "registration4" };


        public MockRestClient()
        {
            carDtos = new CarDto[4];

            for (int i = 0; i < 4; i++)
            {
                carDtos[i] = (CarDto)Activator.CreateInstance(typeof(CarDto));
                carDtos[i].id = i;
                carDtos[i].brand = brandList[i];
                carDtos[i].model = modelList[i];
                carDtos[i].registrationNumber = registrationList[i];

            }
        }

        public async Task AddCar(int Id, string Brand, string Model, string registrationNumber)
        {
            CarDto car = new CarDto();
            car.id = carDtos.Length;
            car.brand = Brand;
            car.model = Model;
            car.registrationNumber = registrationNumber;
            Array.Resize(ref carDtos, carDtos.Length + 1);
            carDtos[carDtos.Length - 1] = car;
        }

        public async Task DeleteCar(string registrationNumber)
        {
            List<CarDto> carsList = carDtos.ToList();
            carsList.RemoveAll(x => x.registrationNumber == registrationNumber);
            carDtos = carsList.ToArray();
        }

        public async Task<CarDto[]> DisplayCars()
        {
            return carDtos;
        }

        public async Task<CarDto[]> FindByBrand(string Brand)
        {
            List<CarDto> cars = new List<CarDto>();
            foreach (CarDto car in carDtos)
            {
                if (car.brand == Brand)
                {
                    cars.Add(car);
                }
            }
            return cars.ToArray();
        }

        public async Task<CarDto[]> FindByModel(string Model)
        {
            List<CarDto> cars = new List<CarDto>();
            foreach (CarDto car in carDtos)
            {
                if (car.model == Model)
                {
                    cars.Add(car);
                }
            }
            return cars.ToArray();

        }

        public async Task<CarDto[]> FindByRegistrationNumber(string registrationNumber)
        {
            List<CarDto> cars = new List<CarDto>();
            foreach (CarDto car in carDtos)
            {
                if (car.registrationNumber == registrationNumber)
                {
                    cars.Add(car);
                }
            }
            return cars.ToArray();
        }
    }
}
