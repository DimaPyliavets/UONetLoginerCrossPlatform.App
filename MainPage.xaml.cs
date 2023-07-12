using UONetLoginerCrossPlatform.Http_Request;
using UONetLoginerCrossPlatform.Network_Checker;

namespace UONetLoginerCrossPlatform
{
    public partial class MainPage : ContentPage
    {
        private NetworkConnectionManager connectionManager;

        public MainPage()
        {
            InitializeComponent();

            connectionManager = new NetworkConnectionManager(new DefaultNetworkConnection());

            LoginButton.IsEnabled = false;
            LogoutButton.IsEnabled = false;

            UsernameEntry.TextChanged += OnEntryTextChanged;
            PasswordEntry.TextChanged += OnEntryTextChanged;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CheckNetworkConnection();
        }

        private async Task CheckNetworkConnection()
        {
            try
            {
                await connectionManager.IsConnectedToNetwork();
                await ConnectionStatusChecking();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            LoginButton.IsEnabled = !string.IsNullOrWhiteSpace(UsernameEntry.Text) && !string.IsNullOrWhiteSpace(PasswordEntry.Text);
        }

        private async void LoginActionBTN(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    await DisplayAlert("Error", "Invalid username or password.", "OK");
                }
                else
                {
                    await PostRequestLogout.Logout();
                    await PostRequestLogin.Login(username, password);
                    await ConnectionStatusChecking();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred during login: {ex.Message}", "OK");
            }
        }

        private async void LogoutActionBTN(object sender, EventArgs e)
        {
            try
            {
                await PostRequestLogout.Logout();
                await DisplayAlert("Logout", "You are logged out.", "OK");
                await ConnectionStatusChecking();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred during logout: {ex.Message}", "OK");
            }
        }

        public async Task ConnectionStatusChecking()
        {
            NetworkConnectionStatusChecker connectionChecker = new NetworkConnectionStatusChecker();
            bool isLoggedIn = await connectionChecker.IsLoggedInToNetwork();

            if (isLoggedIn==true)
            {
                LogoutButton.IsEnabled = isLoggedIn;
            }
        }
    }
}
