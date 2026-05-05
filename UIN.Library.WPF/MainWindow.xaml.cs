using System.Windows;
using UIN.Library.WPF.Services;
using System.Text;
using System.Text.Json;

namespace UIN.Library.WPF
{
    public partial class MainWindow : Window
    {
        private ApiService _api = new ApiService();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameBox.Text;
            var role = RoleBox.Text;

            var success = await _api.Login(username, role);

            if (!success)
            {
                MessageBox.Show("Erreur login");
                return;
            }

            MessageBox.Show("Login réussi !");

            // Gestion des rôles
            if (_api.Role == "reader")
            {
                AddButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
            else if (_api.Role == "editor")
            {
                AddButton.IsEnabled = true;
                DeleteButton.IsEnabled = false;
            }
            else if (_api.Role == "admin")
            {
                AddButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }

            // Décodage JWT
            var tokenParts = _api.AccessToken.Split('.');

            if (tokenParts.Length == 3)
            {
                HeaderBox.Text = DecodeBase64(tokenParts[0]);
                var json = DecodeBase64(tokenParts[1]);
                PayloadBox.Text = System.Text.Json.JsonSerializer.Serialize(
                    System.Text.Json.JsonSerializer.Deserialize<object>(json),
                    new System.Text.Json.JsonSerializerOptions { WriteIndented = true }
                );
                SignatureBox.Text = tokenParts[2];
            }
        }

        private async void LoadBooks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var books = await _api.GetBooks();
                BooksList.ItemsSource = books;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Logout_Click(object sender, RoutedEventArgs e)
        {
            await _api.Logout();

            MessageBox.Show("Déconnecté !");

            BooksList.ItemsSource = null;
        }

        private string DecodeBase64(string base64)
        {
            base64 = base64.Replace('-', '+').Replace('_', '/');

            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }

            var bytes = Convert.FromBase64String(base64);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}