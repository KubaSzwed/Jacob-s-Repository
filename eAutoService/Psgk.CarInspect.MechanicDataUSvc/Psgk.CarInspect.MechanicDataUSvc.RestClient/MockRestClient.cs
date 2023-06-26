namespace Psgk.CarInspect.MechanicDataUSvc.RestClient
{
    using System;
    using System.Threading.Tasks;
    using Psgk.CarInspect.MechanicDataUSvc.RestModel;
    using System.Xml.Linq;

    public class MockRestClient : IRestClient
    {
        private MechanicDto[] mechanicDtos;
        public string[] nameList = new string[] { "name1", "anme2", "name3", "named4" };
        public string[] surnameList = new string[] { "sur1", "sur2", "sur3", "sur4" };
        public string[] workplaceList = new string[] { "place1", "place2", "place3", "place4" };


        public MockRestClient()
        {
            mechanicDtos = new MechanicDto[4];

            for (int i = 0; i < 4; i++)
            {
                mechanicDtos[i] = (MechanicDto)Activator.CreateInstance(typeof(MechanicDto));
                mechanicDtos[i].name = nameList[i];
                mechanicDtos[i].surname = surnameList[i];
                mechanicDtos[i].id = i;
                mechanicDtos[i].workPlace = workplaceList[i];

            }
        }

        public async Task AddMechanic(string Name, string Surname, string WorkPlace)
        {
            MechanicDto mechanic = new MechanicDto();
            mechanic.name = Name;
            mechanic.surname = Surname;
            mechanic.workPlace = WorkPlace;
            Array.Resize(ref mechanicDtos, mechanicDtos.Length + 1);
            mechanicDtos[mechanicDtos.Length - 1] = mechanic;
        }

        public async Task DeleteMechanic(int Id)
        {
            List<MechanicDto> mechanicsList = mechanicDtos.ToList();
            mechanicsList.RemoveAll(x => x.id == Id);
            mechanicDtos = mechanicsList.ToArray();
        }

        public async Task<MechanicDto[]> DisplayMechanics()
        {
            return mechanicDtos;
        }

        public async Task<MechanicDto[]> FindByName(string Name)
        {
            List<MechanicDto> mechanics = new List<MechanicDto>();
            foreach (MechanicDto mechanic in mechanicDtos)
            {
                if (mechanic.name == Name)
                {
                    mechanics.Add(mechanic);
                }
            }
            return mechanics.ToArray();
        }

        public async Task<MechanicDto[]> FindBySurname(string Surname)
        {
            List<MechanicDto> mechanics = new List<MechanicDto>();
            foreach (MechanicDto mechanic in mechanicDtos)
            {
                if (mechanic.surname == Surname)
                {
                    mechanics.Add(mechanic);
                }
            }
            return mechanics.ToArray();

        }

        public async Task<MechanicDto[]> FindByWorkPlace(string WorkPlace)
        {
            List<MechanicDto> mechanics = new List<MechanicDto>();
            foreach (MechanicDto mechanic in mechanicDtos)
            {
                if (mechanic.workPlace == WorkPlace)
                {
                    mechanics.Add(mechanic);
                }
            }
            return mechanics.ToArray();
        }
    }
}
