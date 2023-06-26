namespace Psgk.CarInspect.CarDataUSvc.Logic
{

    using System.Collections.Generic;
    using System.Linq;
    using Psgk.CarInspect.CarDataUSvc.Model;

    public class Cars : ICars
    {
        private const string carsFilename = "Cars.json";
        private static readonly object carLock = new object();

        Car car = new Car();
        static Cars()
        {
            lock (Cars.carLock)
            {
                CarReader carReader = new CarReader();
                List<Car> cars = carReader.ReadCars(carsFilename);

            }
        }

        public IEnumerable<Car> FindByBrand(string Brand)
        {
            lock (Cars.carLock)
            {
                CarReader carReader = new CarReader();
                List<Car> cars = carReader.ReadCars(carsFilename);
                List<Car> list = new List<Car> { };

                foreach (Car car in cars)
                {
                    if (car.Brand == Brand)
                    {
                        list.Add(car);
                    }
                }

                return list;
            }
        }

        public IEnumerable<Car> FindByRegistrationNumber(string RegistrationNumber)
        {
            lock (Cars.carLock)
            {
                CarReader carReader = new CarReader();
                List<Car> cars = carReader.ReadCars(carsFilename);
                List<Car> list = new List<Car> { };

                foreach (Car car in cars)
                {
                    if (car.RegistrationNumber == RegistrationNumber)
                    {
                        list.Add(car);
                    }
                }

                return list;
            }
        }

        public IEnumerable<Car> FindByModel(string Model)
        {
            lock (Cars.carLock)
            {
                CarReader carReader = new CarReader();
                List<Car> cars = carReader.ReadCars(carsFilename);
                List<Car> list = new List<Car> { };

                foreach (Car car in cars)
                {
                    if (car.Model == Model)
                    {
                        list.Add(car);
                    }
                }

                return list;
            }
        }

        public void AddCar(string Brand, string Model, string registrationNumber, int ownerId, int mechanicId)
        {
            lock (Cars.carLock)
            {
                CarReader carReader = new CarReader();
                List<Car> cars = carReader.ReadCars(carsFilename);
                int newId = cars.Max(i => i.Id) + 1;
                Car newCar = new(newId, Brand, Model, registrationNumber, ownerId, mechanicId);
                cars.Add(newCar);
                carReader.SaveCars(carsFilename, cars);
            }
        }

        public void DeleteCar(string registrationNumber)
        {
            lock (Cars.carLock)
            {
                CarReader carReader = new CarReader();
                List<Car> cars = carReader.ReadCars(carsFilename);
                cars.RemoveAll(i => i.RegistrationNumber == registrationNumber);
                carReader.SaveCars(carsFilename, cars);
            }


        }

        public IEnumerable<Car> GetCars()
        {
            lock (Cars.carLock)
            {
                CarReader carReader = new CarReader();
                List<Car> cars = carReader.ReadCars(carsFilename);

                return cars;


            }

        }

        static void Main()

        {

        }


    }
}
