using UONetLoginerCrossPlatform.Data_Strings;

namespace UONetLoginerCrossPlatform.Network_Checker
{
    public class DefaultNetworkConnection : INetworkConnection
    {
        public async Task<bool> IsConnectedToNetwork()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(DataStrings.BaseUOPageLink);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (HttpRequestException)
                {
                    return false;
                }
            }
        }
    }
}
