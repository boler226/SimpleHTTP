using SimpleHTTP.Services;
using SimpleHTTP.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHTTP.Models
{
    public class ProductViewModel : BaseViewModel // Передбачається, що ви маєте базовий клас для реалізації INotifyPropertyChanged
    {
        private readonly ApiClient _apiClient;

        public ProductViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
            Products = new ObservableCollection<Product>();
        }

        public ObservableCollection<Product> Products { get; private set; }

        public async Task LoadProductsAsync()
        {
            try
            {
                var products = await _apiClient.GetProductsAsync();
                if (products != null)
                {
                    Products.Clear();
                    foreach (var product in products)
                    {
                        Products.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void UpdateProductsFromJson(string json)
        {
            // Логіка оновлення списку продуктів із JSON-рядка
        }
    }
}
