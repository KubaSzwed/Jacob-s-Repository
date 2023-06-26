namespace Psgk.CarInspect.MechanicAppService.RestSvc
{
    using Psgk.CarInspect.MechanicAppService.Model;
    using System.Text.Json;
    public class MechanicClient
    {
        public MechanicClient() { }

        public async Task<MechanicDto[]> DisplayMechanics()
        {
            HttpClient httpclient = new HttpClient();
            string requestUri = "https://localhost:7258/Mechanic/DisplayAllMechanics";

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            httpclient.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await httpclient.SendAsync(httpRequestMessage);
            httpclient.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();

            string response = await httpResponseMessage.Content.ReadAsStringAsync();
            MechanicDto[] mechanicDtos = JsonSerializer.Deserialize<MechanicDto[]>(response);

            return mechanicDtos;
        }

        public async Task<MechanicDto[]> FindByName(string Name)
        {
            HttpClient client = new HttpClient();
            string requestUri = "https://localhost:7258/Mechanic/FindMechanicByName/" + Name;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            client.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();

            string response = await httpResponseMessage.Content.ReadAsStringAsync();
            MechanicDto[] mechanicDtos = JsonSerializer.Deserialize<MechanicDto[]>(response);

            return mechanicDtos;
        }

        public async Task<MechanicDto[]> FindBySurname(string Surname)
        {
            HttpClient client = new HttpClient();
            string requestUri = "https://localhost:7258/Mechanic/FindMechanicBySurname/" + Surname;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            client.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();

            string response = await httpResponseMessage.Content.ReadAsStringAsync();
            MechanicDto[] mechanicDtos = JsonSerializer.Deserialize<MechanicDto[]>(response);

            return mechanicDtos;
        }
        public async Task<MechanicDto[]> FindByWorkPlace(string WorkPlace)
        {
            HttpClient client = new HttpClient();
            string requestUri = "https://localhost:7258/Mechanic/FindMechanicByWorkPlace/" + WorkPlace;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            client.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();

            string response = await httpResponseMessage.Content.ReadAsStringAsync();
            MechanicDto[] mechanicDtos = JsonSerializer.Deserialize<MechanicDto[]>(response);

            return mechanicDtos;
        }
        public async Task AddMechanic(string Name, string Surname, string WorkPlace)
        {
            HttpClient client = new HttpClient();
            string requestUri = "https://localhost:7258/Mechanic/AddMechanic/" + Name + "/" + Surname + "/" + WorkPlace;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            client.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();

        }

        public async Task DeleteMechanic(int Id)
        {
            HttpClient client = new HttpClient();
            string requestUri = "https://localhost:7258/Mechanic/DeleteMechanic/" + Id;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            client.Dispose();
            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
