namespace Psgk.CarInspect.CustomerDataUSvc.RestSvc.Mapper
{
    using Psgk.CarInspect.CustomerDataUSvc.Model;
    using Psgk.CarInspect.CustomerDataUSvc.RestModel;

    public static class Mapper
    {
        public static CustomerDto Map(this Customer customer)
        {

            if (customer == null)
            {
                return null;
            }

            return new CustomerDto
            {
                id = customer.Id,
                name = customer.Name,
                address = customer.Address,
                phone = customer.Phone,
                email = customer.Email,
            };
        }
    }
}
