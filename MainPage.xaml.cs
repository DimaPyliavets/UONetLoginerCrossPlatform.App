using Plugin.LocalNotification;
using UONetLoginerCrossPlatform.Data_Strings;
using UONetLoginerCrossPlatform.Http_Request;
using UONetLoginerCrossPlatform.Local_Notification;
using UONetLoginerCrossPlatform.Network_Checker;

namespace UONetLoginerCrossPlatform
{
    public partial class MainPage : ContentPage
    {
        public static string connectionStatus;

        private NetworkConnectionManager connectionManager;
        private LocalPushNotification localNotification = new LocalPushNotification();

        public MainPage()
        {
            InitializeComponent();
            connectionManager = new NetworkConnectionManager(new DefaultNetworkConnection());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CheckNetworkConnection();
            await localNotification.ShowNotification("UONet", "Notification Subtitle", connectionStatus);
        }

        private async Task CheckNetworkConnection()
        {
            try
            {
                bool isConnected = await connectionManager.IsConnectedToNetwork();
                connectionStatus = isConnected ? "You are connected to the UONet." : "You are not connected to the network.";
                await DisplayAlert("Network Connection", connectionStatus, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        private async void LoginActionBTN(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;
            try
            {
                PostRequestLogin postRequestLogin = new PostRequestLogin();
                await postRequestLogin.Login(username, password);
                string responseContent = postRequestLogin.responseContent;
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
                PostRequestLogout postRequestLogout = new PostRequestLogout();
                await postRequestLogout.Logout();
                await DisplayAlert("Logout", "You are logged out.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred during logout: {ex.Message}", "OK");
            }
        }
    }
}
