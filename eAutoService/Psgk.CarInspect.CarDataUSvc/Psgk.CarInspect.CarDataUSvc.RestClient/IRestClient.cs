
namespace Psgk.CarInspect.CarDataUSvc.RestClient
{
    using Psgk.CarInspect.CarDataUSvc.RestModel;
    public interface IRestClient
    {
        Task<CarDto[]> DisplayCars();

        Task<CarDto[]> FindByBrand(string Brand);

        Task<CarDto[]> FindByRegistrationNumber(string registrationNumber);

        Task<CarDto[]> FindByModel(string Model);

        Task AddCar(string Brand, string Model, string registrationNumber, int ownerId, int mechanicId);

        Task DeleteCar(string registrationNumber);
    }
}
