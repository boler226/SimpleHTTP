using SimpleHTTP.Server;
using System;
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

namespace SimpleHTTP.Views
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly DistributorProduct _distributor;
        public RegisterWindow(DistributorProduct distributor)
        {
            InitializeComponent();
            _distributor = distributor;
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            bool isRegister = await _distributor._apiClient.RegisterAsync(new Models.Users.RegisterViewModel(firstName, lastName, "", email, password));

            if (isRegister)
            {
                this.Close();
                LoginWindow login = new LoginWindow(_distributor);
                login.ShowDialog();
            }
            else
            {

            }
        }
    }
}
