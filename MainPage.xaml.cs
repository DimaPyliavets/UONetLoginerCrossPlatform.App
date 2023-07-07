
using UONetLoginerCrossPlatform.Network_Checker;

namespace UONetLoginerCrossPlatform;

public partial class MainPage : ContentPage
{

    private NetworkConnectionManager connectionManager;
    public MainPage()
	{
		InitializeComponent();
        connectionManager = new NetworkConnectionManager(new DefaultNetworkConnection());
        OnStartCheckingConnection();


    }

    private async void OnStartCheckingConnection() 
    {
        try
        {
            bool isConnected = await connectionManager.IsConnectedToNetwork();

            string connectionStatus = isConnected ? "You are connected to the network." : "You are not connected to the network.";

            await DisplayAlert("Network Connection", connectionStatus, "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }

}

