using SimpleHTTP.Views;
using SimpleHTTP.Models;
using SimpleHTTP.Server;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimpleHTTP.Accounts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DistributorProduct _distributor;
        public MainWindow()
        {
            InitializeComponent();
            _distributor = new DistributorProduct(new Services.ApiClient("http://localhost:5255"));
            DataContext = _distributor;
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _distributor.LoadProductsAsync();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
        
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow(_distributor);
            login.ShowDialog(); 
        }
        private void CartButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
