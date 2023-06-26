
namespace Psgk.CarInspect.MechanicDataUSvc.WebService.QueriesHandler
{
    using Psgk.CarInspect.MechanicDataUSvc.RestModel;

    public interface IMechanicQueriesHandler
    {
        IEnumerable<MechanicDto> FindByName(string Name);

        IEnumerable<MechanicDto> FindBySurname(string Surname);

        IEnumerable<MechanicDto> FindByWorkPlace(string WorkPlace);

        IEnumerable<MechanicDto> DisplayMechanics();

        public void AddMechanic(string Name, string Surname, string WorkPlace);
        public void DeleteMechanic(int Id);

    }
}

