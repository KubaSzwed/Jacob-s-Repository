namespace Psgk.CarInspect.CarDataUSvc.RestClient
{
    using RestModel;
    using System.Text.Json;

    public class RestClient : IRestClient
    {
        public RestClient() { }

        public async Task<CarDto[]> DisplayCars()
        {
            HttpClient httpclient = new HttpClient();
            string requestUri = "https://localhost:7100/Car/DisplayCars";

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            httpclient.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await httpclient.SendAsync(httpRequestMessage);
            httpclient.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();

            string response = await httpResponseMessage.Content.ReadAsStringAsync();
            CarDto[] carDtos = JsonSerializer.Deserialize<CarDto[]>(response);

            return carDtos;
        }

        public async Task<CarDto[]> FindByBrand(string Brand)
        {
            HttpClient client = new HttpClient();
            string requestUri = "https://localhost:7100/Car/FindCarByBrand/{Brand}";

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            client.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();

            string response = await httpResponseMessage.Content.ReadAsStringAsync();
            CarDto[] carDtos = JsonSerializer.Deserialize<CarDto[]>(response);

            return carDtos;
        }

        public async Task<CarDto[]> FindByRegistrationNumber(string registrationNumber)
        {
            HttpClient client = new HttpClient();
            string requestUri = "https://localhost:7100/Car/FindCarByRegistrationNumber/{registrationNumber}" ;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            client.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();

            string response = await httpResponseMessage.Content.ReadAsStringAsync();
            CarDto[] carDtos = JsonSerializer.Deserialize<CarDto[]>(response);

            return carDtos;
        }
        public async Task<CarDto[]> FindByModel(string Model)
        {
            HttpClient client = new HttpClient();
            string requestUri = "https://localhost:7100/Car/FindCarByModel/{Model}";

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            client.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();

            string response = await httpResponseMessage.Content.ReadAsStringAsync();
            CarDto[] carDtos = JsonSerializer.Deserialize<CarDto[]>(response);

            return carDtos;
        }
        public async Task AddCar(string Brand, string Model, string registrationNumber, int ownerId, int mechanicId)
        {
            HttpClient client = new HttpClient();
            string requestUri = "https://localhost:7100/Car/AddCar/{Brand}/{Model}/{registrationNumber}/{ownerId}/{mechanicId}";

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            client.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();

        }

        public async Task DeleteCar(string registrationNumber)
        {
            HttpClient client = new HttpClient();
            string requestUri = "https://localhost:7100/Car/DeleteCar/{registrationNumber}";

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            client.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}