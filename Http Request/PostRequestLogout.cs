using System;
using System.Net.Http;
using System.Threading.Tasks;
using UONetLoginerCrossPlatform.Data_Strings;

namespace UONetLoginerCrossPlatform.Http_Request
{
    public class PostRequestLogout
    {
        public static async Task Logout()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(DataStrings.BaseUOPageLink);
            await httpClient.PostAsync("logout?", null);
        }
    }
}
