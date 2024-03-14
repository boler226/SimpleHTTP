using Newtonsoft.Json;
using SimpleHTTP.Models;
using SimpleHTTP.Models.Users;
using SimpleHTTP.ViewModel;
using SimpleHTTP.Helpers;
using SimpleHTTP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace SimpleHTTP.Services
{
    public class ApiClient
    {
        private readonly string _baseUrl;
        private ImageWorker _worker;

        public ApiClient(string baseUrl)
        {
            _baseUrl = baseUrl;
            _worker = new ImageWorker();
        }

        public async Task<ProductResultViewModel> GetProductsAsync()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync($"{_baseUrl}/api/Products");

                    response.EnsureSuccessStatusCode();

                    var jsonString = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ProductResultViewModel>(jsonString);
                    
                    string baseImageUrl = "http://localhost:5255/Images/";

                    foreach (var product in data.List)
                    {
                        if (product.Images != null && product.Images.Count > 0)
                        {
                            string imageUrl = baseImageUrl + product.Images[0];
                            product.BitmapImage = await _worker.DownloadImageAsync(imageUrl);
                        }
                    }

                    return data;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка при виконанні запиту: {ex.Message}");
                    return null;
                }
            }
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            using(var client = new HttpClient()) 
            {
                try
                {
                    var loginData = new LoginViewModel { Email = email, Password = password };
                    var json = JsonConvert.SerializeObject(loginData);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(_baseUrl + "/api/Account/login", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Вхід успішний
                        return true;
                    }
                    else
                    {
                        // Вхід не вдалий
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public async Task<bool> RegisterAsync(RegisterViewModel model)
        {
            using(var client = new HttpClient()) 
            {
                try
                {
                    var json = JsonConvert.SerializeObject(model);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(_baseUrl + "/api/Account/register", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}
