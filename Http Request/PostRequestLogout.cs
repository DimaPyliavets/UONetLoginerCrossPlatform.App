using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UONetLoginerCrossPlatform.Http_Request
{
    public class PostRequestLogout
    {
        public async Task Logout()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://uonet.uni.opole.pl/");
            HttpResponseMessage response = await httpClient.PostAsync("logout", null);
        }
    }
}
