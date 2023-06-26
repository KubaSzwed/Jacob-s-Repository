namespace Psgk.CarInspect.MechanicAppService.RestSvc
{
    public class ServiceDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }

        public int[] carid { get; set; }

        public ServiceDto()
        {
        }

        public ServiceDto(int Id, string Name, int Price)
        {
            id = Id;
            name = Name;
            price = Price;
        }
    }
}
