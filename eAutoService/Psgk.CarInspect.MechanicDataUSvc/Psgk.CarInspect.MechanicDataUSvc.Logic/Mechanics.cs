
namespace Psgk.CarInspect.MechanicDataUSvc.Logic
{
    using Psgk.CarInspect.MechanicDataUSvc.Model;
    using System.Collections.Generic;
    using System.Linq;

    public class Mechanics : IMechanics
    {
        private const string mechanicsFilename = "DataMechanics.json";
        private static readonly object mechanicLock = new object();
        private static List<Mechanic> mechanicsList = new List<Mechanic>();
        static Mechanics()
        {
            lock (Mechanics.mechanicLock)
            {
                MechanicReader mechanicReader = new MechanicReader();
                List<Mechanic> mechanics = mechanicReader.ReadMechanics(mechanicsFilename);
                mechanicsList = mechanics;
            }
        }

        public IEnumerable<Mechanic> DisplayMechanics()
        {
            lock (Mechanics.mechanicLock)
            {
                MechanicReader mechanicReader = new MechanicReader();
                List<Mechanic> mechanics = mechanicReader.ReadMechanics(mechanicsFilename);
                mechanicsList = mechanics;
                return mechanicsList;
            }
        }

        public IEnumerable<Mechanic> FindByName(string Name)
        {
            lock (Mechanics.mechanicLock)
            {
                MechanicReader mechanicReader = new MechanicReader();
                List<Mechanic> mechanics = mechanicReader.ReadMechanics(mechanicsFilename);
                List<Mechanic> list = new List<Mechanic> { };

                foreach (Mechanic mechanic in mechanics)
                {
                    if (mechanic.Name == Name)
                    {
                        list.Add(mechanic);
                    }
                }

                return list;
            }
        }



        public IEnumerable<Mechanic> FindBySurname(string Surname)
        {
            lock (Mechanics.mechanicLock)
            {
                MechanicReader mechanicReader = new MechanicReader();
                List<Mechanic> mechanics = mechanicReader.ReadMechanics(mechanicsFilename);
                List<Mechanic> list = new List<Mechanic> { };

                foreach (Mechanic mechanic in mechanics)
                {
                    if (mechanic.Surname == Surname)
                    {
                        list.Add(mechanic);
                    }
                }

                return list;
            }
        }
        public IEnumerable<Mechanic> FindByWorkPlace(string WorkPlace)
        {
            lock (Mechanics.mechanicLock)
            {
                MechanicReader mechanicReader = new MechanicReader();
                List<Mechanic> mechanics = mechanicReader.ReadMechanics(mechanicsFilename);
                List<Mechanic> list = new List<Mechanic> { };

                foreach (Mechanic mechanic in mechanics)
                {
                    if (mechanic.WorkPlace == WorkPlace)
                    {
                        list.Add(mechanic);
                    }
                }

                return list;
            }
        }

        public void AddMechanic(string Name, string Surname, string WorkPlace)
        {
            lock (Mechanics.mechanicLock)
            {
                MechanicReader mechanicReader = new MechanicReader();
                List<Mechanic> mechanics = mechanicReader.ReadMechanics(mechanicsFilename);
                int nextId = mechanics.Max(i => i.Id) + 1;
                mechanicReader.WriteInspections(mechanicsFilename, new Mechanic(Name, Surname, nextId, WorkPlace));

            }
        }


        public void DeleteMechanic(int Id)
        {
            lock (Mechanics.mechanicLock)
            {
                MechanicReader mechanicReader = new MechanicReader();
                mechanicReader.DeleteMechanics(mechanicsFilename, Id);
            }

        }




        static void Main()

        {

        }





    }
}
