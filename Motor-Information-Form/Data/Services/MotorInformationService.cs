using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;
using Motor_Information_Form.Data.Models;

namespace Motor_Information_Form.Data.Services
{
    public class MotorInformationService
    {
        private static readonly string BaseUrl = "https://driver-vehicle-licensing.api.gov.uk/vehicle-enquiry/v1/vehicles";
        private readonly HttpClient _httpClient;

        public MotorInformationService(string apiKey)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
        }

        public virtual async Task<MotorInformation> PostReg(string registrationNumber)
        {
            var requestBody = new { registrationNumber = registrationNumber };
            var response = await _httpClient.PostAsJsonAsync(string.Empty, requestBody);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"API request failed with status code {response.StatusCode}, Response: {errorContent}");
            }

            var motorInformation = await response.Content.ReadFromJsonAsync<MotorInformation>();

            if (motorInformation == null)
            {
                throw new HttpRequestException("Deserialization has returned null, please check JSON data.");
            }

            return motorInformation;
        }
    }
}
