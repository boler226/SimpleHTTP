using Newtonsoft.Json;
using SimpleHTTP.Models;
using SimpleHTTP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHTTP.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ApiClient(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync($"{_baseUrl}/api/Products");

                    response.EnsureSuccessStatusCode();

                    var jsonString = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ProductResultViewModel>(jsonString);
                    
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка при виконанні запиту: {ex.Message}");
                    return null;
                }
            }
        }
    }
}
