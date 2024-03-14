using SimpleHTTP.Accounts;
using SimpleHTTP.Models;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly DistributorProduct _distributor;
        public LoginWindow(DistributorProduct distributor)
        {
            InitializeComponent();
            _distributor = distributor;
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            bool loginResult = await _distributor._apiClient.LoginAsync(email, password);

            if (loginResult)
            {
                this.Close();
            }
            else
            {

            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            RegisterWindow register = new RegisterWindow(_distributor);
            register.ShowDialog();
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;
            textBlock.Foreground = Brushes.Green;
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;
            textBlock.Foreground = Brushes.Black;
        }
    }
}
