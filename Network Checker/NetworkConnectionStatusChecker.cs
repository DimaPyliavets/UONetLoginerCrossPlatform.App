using System.Net.Http;
using System.Threading.Tasks;
using UONetLoginerCrossPlatform.Data_Strings;

namespace UONetLoginerCrossPlatform.Network_Checker
{
    public class NetworkConnectionStatusChecker
    {
        public async Task<bool> IsLoggedInToNetwork()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(DataStrings.BaseUOPageLink);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseUrl = response.RequestMessage.RequestUri.ToString();

                        if (responseUrl.Contains(DataStrings.StatusUOWord))
                        {
                            return true;
                        }
                        else if (responseUrl.Contains(DataStrings.LoginUOWord))
                        {
                            return false;
                        }
                    }
                }
                catch (HttpRequestException){}

                return false;
            }
        }
    }
}
