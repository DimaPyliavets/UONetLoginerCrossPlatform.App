namespace UONetLoginerCrossPlatform.Network_Checker
{
    public class NetworkConnectionManager
    {
        private INetworkConnection connection;

        public NetworkConnectionManager(INetworkConnection connect)
        {
            connection = connect;
        }

        public async Task<bool> IsConnectedToNetwork()
        {
            return await connection.IsConnectedToNetwork();
        }
    }
}
