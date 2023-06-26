namespace Psgk.CarInspect.CustomerDataUSvc.RestClient
{

    using System.Text.Json;
    using System.Xml.Linq;
    using global::Psgk.CarInspect.CustomerDataUSvc.RestModel;
    using Psgk.CarInspect.CustomerDataUSvc.RestModel;

    public class RestClient
    {
        public RestClient() { }

        public async Task<CustomerDto[]> GetCustomers()
        {
            HttpClient httpclient = new HttpClient();
            string requestUri = "https://localhost:7206/Customer/DisplayAllCustomer";

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            httpclient.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await httpclient.SendAsync(httpRequestMessage);
            httpclient.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();

            string response = await httpResponseMessage.Content.ReadAsStringAsync();
            CustomerDto[] csutomerDtos = JsonSerializer.Deserialize<CustomerDto[]>(response);

            return csutomerDtos;
        }
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

        public async Task<CustomerDto[]> FindCustomerByName(string name)
        {
            HttpClient client = new HttpClient();
            string requestUri = $"https://localhost:7206/Customer/GetCustomerByName?name={name}";

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

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            client.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}