

namespace Psgk.CarInspect.MechanicDataUSvc.WebService.Mapper
{
    using Psgk.CarInspect.MechanicDataUSvc.Model;
    using Psgk.CarInspect.MechanicDataUSvc.RestModel;
    public static class Mapper
    {
        public static MechanicDto Map (this Mechanic mechanic)
        {
            if(mechanic == null)
            {
                return null;
            }
            return new MechanicDto
            {
                name = mechanic.Name,
                surname = mechanic.Surname,
                id = mechanic.Id,
                workPlace = mechanic.WorkPlace,
            };

        }


    }
}


