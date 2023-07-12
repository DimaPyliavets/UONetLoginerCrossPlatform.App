using UONetLoginerCrossPlatform.Local_Notification;
using UONetLoginerCrossPlatform.Network_Checker;

namespace UONetLoginerCrossPlatform
{
    public partial class App : Application
    {
        private LocalPushNotification localNotification;
        private NetworkConnectionManager connectionManager;

        public App()
        {
            InitializeComponent();
            connectionManager = new NetworkConnectionManager(new DefaultNetworkConnection());
            localNotification = new LocalPushNotification();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            Task.Run(RegisterBackgroundTask);
        }

        protected override void OnSleep(){}

        protected override void OnResume(){}

        private async Task RegisterBackgroundTask()
        {
            try
            {
                bool isConnected = await connectionManager.IsConnectedToNetwork();
                if (isConnected) 
                {
                    NetworkConnectionStatusChecker connectionChecker = new NetworkConnectionStatusChecker();
                    bool isLoggedIn = await connectionChecker.IsLoggedInToNetwork();

                    if (isLoggedIn)
                    {
                        await localNotification.ShowNotification("UONet", "Status", "You are logged in.");
                    }
                    else
                    {
                        await localNotification.ShowNotification("UONet", "Status", "You are logged out.");
                    }
                } 
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }

            
        }
    }
}
