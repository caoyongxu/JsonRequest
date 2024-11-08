using Azure;
using Azure.Core;
using Azure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JsonRequest
{
    public class HttpRequestHelper
    {
        public static async Task<string> ExecuteHttpPostAsync(string jsonData, string endPoint, string token = null)
        {
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, endPoint);

            if (token != null && request.Headers.Authorization == null)
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public static AccessToken GetAADPersonalToken()
        {
            DefaultAzureCredential defaultAzureCredential = new DefaultAzureCredential();
            AccessToken AzOpenAIAccessToken = defaultAzureCredential.GetToken(
                new TokenRequestContext(new string[] { "https://content-proxy-sandbox.docs.microsoft.com/.default" }));
            return AzOpenAIAccessToken;
        }

    }
}
