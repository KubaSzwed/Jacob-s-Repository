
namespace Psgk.CarInspect.MechanicDataUSvc.Model
{
    public interface IMechanics
    {
        IEnumerable<Mechanic> FindByName(string Name);

        IEnumerable<Mechanic> FindBySurname(string Surname);

        IEnumerable<Mechanic> FindByWorkPlace(string WorkPlace);

        IEnumerable<Mechanic> DisplayMechanics();

        public void AddMechanic(string Name, string Surname, string WorkPlace);

        public void DeleteMechanic(int Id);



    }
}
