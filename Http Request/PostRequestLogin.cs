using UONetLoginerCrossPlatform.Data_Strings;

namespace UONetLoginerCrossPlatform.Http_Request
{
    public class PostRequestLogin
    {
        public static async Task<string> Login(string username, string password)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(DataStrings.BaseUOPageLink);

            var parameters = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("dst", ""),
                new KeyValuePair<string, string>("popup", "true"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            HttpResponseMessage response = await httpClient.PostAsync("login", parameters);
            string responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;
        }
    }
}
