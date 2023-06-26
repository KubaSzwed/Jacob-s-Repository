namespace Psgk.CarInspect.MechanicAppService.RestSvc
{
    using System.Text;
    using System.Text.Json;
    public class ServiceClient
    {
        public ServiceClient() { }

        public async Task<ServiceDto[]> GetServices()
        {
            HttpClient httpclient = new HttpClient();
            string requestUri = "https://localhost:7098/Service/GetAllServices";

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            httpclient.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await httpclient.SendAsync(httpRequestMessage);
            httpclient.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();

            string response = await httpResponseMessage.Content.ReadAsStringAsync();
            ServiceDto[] serviceDtos = JsonSerializer.Deserialize<ServiceDto[]>(response);

            return serviceDtos;
        }


        public async Task<ServiceDto[]> FindById(int id)
        {
            HttpClient client = new HttpClient();
            string requestUri = "https://localhost:7098/Service/GetServiceById/" + id;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            client.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();

            string response = await httpResponseMessage.Content.ReadAsStringAsync();
            ServiceDto[] serviceDtos = JsonSerializer.Deserialize<ServiceDto[]>(response);

            return serviceDtos;
        }


        public async Task AddService(int Id, string Name, int Price, int[] CarId)
        {
            HttpClient client = new HttpClient();
            string requestUri = "https://localhost:7098/Service/AddService?Id=" + Id + "&Name=" + Name + "&Price=" + Price;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            httpRequestMessage.Headers.Add("Content-Type", "application/json");

            string carIdJson = JsonSerializer.Serialize(CarId); // Convert CarId array to JSON using System.Text.Json
            httpRequestMessage.Content = new StringContent(carIdJson, Encoding.UTF8, "application/json"); // Add JSON content to the request

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            client.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task DeleteService(int Id)
        {
            HttpClient client = new HttpClient();
            string requestUri = "https://localhost:7098/Service/DeleteService/Id=" + Id;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            client.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
