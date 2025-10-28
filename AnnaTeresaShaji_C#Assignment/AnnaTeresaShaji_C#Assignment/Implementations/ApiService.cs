using AnnaTeresaShaji_C_Assignment.Interfaces;
using AnnaTeresaShaji_C_Assignment.Models;
using System.Text.Json;

namespace AnnaTeresaShaji_C_Assignment.Implementations
{
    public class ApiService : IApiService
    {
        private readonly string apiurl = "https://rc-vault-fap-live-1.azurewebsites.net/api/gettimeentries?code=vO17RnE8vuzXzPJo5eaLLjXjmRW07law99QTD90zat9FfOQJKKUcgQ==";

        public async Task<List<EmployeeDataModel>> GetEmployeeData()
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync(apiurl);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<List<EmployeeDataModel>>(response, options);
        }
    }
}
