namespace UONetLoginerCrossPlatform.Network_Checker
{
    public interface INetworkConnection
    {
        Task<bool> IsConnectedToNetwork();
    }
}
