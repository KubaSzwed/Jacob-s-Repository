namespace Psgk.CarInspect.MechanicDataUSvc.RestClient
{
    using Psgk.CarInspect.MechanicDataUSvc.RestModel;

    public interface IRestClient
    {
        Task<MechanicDto[]> FindByName(string Name);

        Task<MechanicDto[]> FindBySurname(string Surname);

        Task<MechanicDto[]> FindByWorkPlace(string WorkPlace);

        Task<MechanicDto[]> DisplayMechanics();

        Task AddMechanic(string Name, string Surname, string WorkPlace);

        Task DeleteMechanic(int Id);
    }
}