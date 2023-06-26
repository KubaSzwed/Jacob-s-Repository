namespace Psgk.CarInspect.ClientAppService.Rest
{
    using Psgk.CarInspect.ClientAppService.Model;
    using Psgk.CarInspect.ClientAppService.RestModel;
    using System.Net.Http;
    using System.Text.Json;


    public class RestClient
    {
        public RestClient() { }

        private string portNumer = "7111";

        public async Task<CustomerDto[]> FindCustomerById(int Id)
        {
            HttpClient client = new HttpClient();
            string requestUri = $"https://localhost:7206/Customer/GetCustomerById?id={Id}";

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            client.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();

            string response = await httpResponseMessage.Content.ReadAsStringAsync();
            CustomerDto[] customerDtos = JsonSerializer.Deserialize<CustomerDto[]>(response);

            return customerDtos;
        }

        public async Task AddCustomer(int Id, string Name, string Address, string Phone, string Email)
        {
            HttpClient client = new HttpClient();
            string requestUri = "https://localhost:7206/Customer/AddCustomer?Id=" + Id + "&Name=" + Name + "&Address=" + Address + "&Phone=" + Phone + "&Email=" + Email;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            client.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();

        }

        public async Task DeleteCustomer(int Id)
        {
            HttpClient client = new HttpClient();
            string requestUri = "https://localhost:7206/Customer/DeleteCustomer?CustomerId=" + Id;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, requestUri); // Zmiana metody na HttpMethod.Delete
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            client.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();
        }

    }
}
