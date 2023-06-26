namespace Psgk.CarInspect.CarDataUSvc.RestSvc1.Mapper
{
    using Psgk.CarInspect.CarDataUSvc.Model;
    using Psgk.CarInspect.CarDataUSvc.RestModel;

    public static class Mapper
    {
        public static CarDto Map(this Car car)
        {

            if (car == null)
            {
                return null;
            }

            return new CarDto
            {
                id = car.Id,
                brand = car.Brand,
                model = car.Model,
                registrationNumber = car.RegistrationNumber,
                
            };
        }
    }
}
