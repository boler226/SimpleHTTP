using SimpleHTTP.Services;
using SimpleHTTP.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHTTP.Server
{
    public class DistributorProduct : ObservableProduct // Передбачається, що ви маєте базовий клас для реалізації INotifyPropertyChanged
    {
        public readonly ApiClient _apiClient;

        public DistributorProduct(ApiClient apiClient)
        {
            _apiClient = apiClient;
            Products = new ObservableCollection<ProductItemViewModel>();
        }

        public ObservableCollection<ProductItemViewModel> Products { get; private set; }

        public async Task LoadProductsAsync()
        {
            try
            {
                var products = await _apiClient.GetProductsAsync();
                if (products != null && products.List != null)
                {
                    Products.Clear();
                    foreach (var product in products.List)
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
