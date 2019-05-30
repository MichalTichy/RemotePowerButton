using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RemotePowerButton.API.Connector
{
    public class ApiConnector
    {
        protected static readonly HttpClient client = new HttpClient();
        protected readonly string ApiAddress;
        protected readonly string accessToken;

        public ApiConnector(string apiAddress,string accessToken)
        {
            ApiAddress = apiAddress;
            this.accessToken = accessToken;
        }
        public async Task<HttpResponseMessage> SendShortButtonPress()
        {
            var httpResponseMessage = await client.SendAsync(new HttpRequestMessage(HttpMethod.Post, $@"{ApiAddress}/powerButton/short?token={accessToken}"));
            return httpResponseMessage;
        }

        public async Task<HttpResponseMessage> SendLongButtonPress()
        {
            var httpResponseMessage = await client.SendAsync(new HttpRequestMessage(HttpMethod.Post, $@"{ApiAddress}/powerButton/short?token={accessToken}"));
            return httpResponseMessage;

        }

        public async Task<bool> IsOnline()
        {
            try
            {
                var httpResponseMessage = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, $@"{ApiAddress}/status"));

                return httpResponseMessage.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }
    }
}
