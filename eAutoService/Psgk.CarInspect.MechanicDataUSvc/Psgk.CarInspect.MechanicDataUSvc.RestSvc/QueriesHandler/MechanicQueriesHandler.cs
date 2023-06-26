

namespace Psgk.CarInspect.MechanicDataUSvc.WebService.QueriesHandler
{
    using Psgk.CarInspect.MechanicDataUSvc.Model;
    using Psgk.CarInspect.MechanicDataUSvc.Logic;
    using Psgk.CarInspect.MechanicDataUSvc.RestModel;
    using Psgk.CarInspect.MechanicDataUSvc.WebService.Mapper;

    public class MechanicQueriesHandler : IMechanicQueriesHandler
    {
        private readonly IMechanics mechanics;
        public MechanicQueriesHandler()
        {
            this.mechanics = new Mechanics();        
        }

        public IEnumerable<MechanicDto> DisplayMechanics()
        {
            return mechanics.DisplayMechanics().Select(x => x.Map());
        }
        public IEnumerable<MechanicDto> FindByName(string Name)
        {
            return mechanics.FindByName(Name).Select(x => x.Map());
        }
        public IEnumerable<MechanicDto> FindBySurname(string Surname)
        {
            return mechanics.FindBySurname(Surname).Select(x => x.Map());
        }

        public IEnumerable<MechanicDto> FindByWorkPlace(string WorkPlace)
        {
            return mechanics.FindByWorkPlace(WorkPlace).Select(x => x.Map());
        }
        public void AddMechanic(string Name, string Surname, string WorkPlace)
        {
            mechanics.AddMechanic(Name, Surname, WorkPlace);
        }
        public void DeleteMechanic(int Id)
        {
            mechanics.DeleteMechanic(Id);
        }
       

    }


}







