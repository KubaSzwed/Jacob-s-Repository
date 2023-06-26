namespace Psgk.CarInspect.ClientAppService.Rest
{

    using Psgk.CarInspect.MechanicAppService.Model;
    using Psgk.CarInspect.MechanicAppService.RestModel;
    using System.Net.Http;
    using System.Text.Json;


    public class RestClient
    {
        public RestClient() { }

        private string portNumer = "7111";



        public async Task<CustomerDto> GetCustomerInfo(int id)
        {
            string url = $"https://localhost:7111/Customer/GetCustomerById?id={id}";
            HttpResponseMessage response;
            HttpClient _httpClient = new HttpClient();
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/plain"));

                response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    //var result = await response.Content.ReadAsStringAsync();
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                    CustomerDto[] results = JsonSerializer.Deserialize<CustomerDto[]>(result);
                    return results[0];
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }

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

        public async Task<CustomersCar[]> DisplayCustomerCars(int id)
        {
            {
                HttpClient httpclient = new HttpClient();
                string requestUri = "https://localhost:7012/Car/DisplayCars";

                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
                httpclient.DefaultRequestHeaders.Add("Accept", "application/json");

                HttpResponseMessage httpResponseMessage = await httpclient.SendAsync(httpRequestMessage);
                httpclient.Dispose();
                httpResponseMessage.EnsureSuccessStatusCode();

                string response = await httpResponseMessage.Content.ReadAsStringAsync();
                CarDto[] carDtos = JsonSerializer.Deserialize<CarDto[]>(response);
                List<CustomersCar> customersCar = new List<CustomersCar>();

                foreach (CarDto obj in carDtos)
                {
                    if (obj.ownerId == id)
                    {
                        CustomersCar customerCar = new CustomersCar(obj.id, obj.brand, obj.model, obj.registrationNumber);
                        customersCar.Add(customerCar);
                    }

                }

                return customersCar.ToArray();
            }


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

        public async Task<ServiceData[]> DisplayServices(int id)
        {
            string url = "https://localhost:5001/Network/ShowServices";
            HttpResponseMessage response;
            HttpClient _httpClient = new HttpClient();
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/plain"));

                response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    //var result = await response.Content.ReadAsStringAsync();
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                    ServiceDto[] results = JsonSerializer.Deserialize<ServiceDto[]>(result);
                    List<ServiceData> serviceData = new List<ServiceData>();


                    foreach (ServiceDto obj in results)
                    {

                        if (Array.IndexOf(obj.carid, id) >= 0)
                        {
                            ServiceData serviceData1 = new ServiceData(obj.id, obj.name, obj.price);
                            serviceData.Add(serviceData1);
                        }

                    }

                    return serviceData.ToArray();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
        public async Task<MechanicCar[]> DisplayMechanicCars(int id)
        {
            {
                HttpClient httpclient = new HttpClient();
                string requestUri = "https://localhost:7012/Car/DisplayCars";

                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
                httpclient.DefaultRequestHeaders.Add("Accept", "application/json");

                HttpResponseMessage httpResponseMessage = await httpclient.SendAsync(httpRequestMessage);
                httpclient.Dispose();
                httpResponseMessage.EnsureSuccessStatusCode();

                string response = await httpResponseMessage.Content.ReadAsStringAsync();
                CarDto[] carDtos = JsonSerializer.Deserialize<CarDto[]>(response);
                List<MechanicCar> mechanicCars = new List<MechanicCar>();

                foreach (CarDto obj in carDtos)
                {
                    if (obj.mechanicId == id)
                    {
                        MechanicCar mechanicCar = new MechanicCar(obj.id, obj.brand, obj.model, obj.registrationNumber);
                        mechanicCars.Add(mechanicCar);
                    }

                }

                return mechanicCars.ToArray();
            }


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

    }
}
