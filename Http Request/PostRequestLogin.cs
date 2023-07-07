using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UONetLoginerCrossPlatform.Http_Request
{
    public class PostRequestLogin
    {
        public string responseContent;
        public async Task Login(string username, string password)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://uonet.uni.opole.pl/");
            var parameters = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("dst", ""),
                new KeyValuePair<string, string>("popup", "true"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });
            HttpResponseMessage response = await httpClient.PostAsync("login", parameters);
            responseContent = await response.Content.ReadAsStringAsync();
        }
    }
}
