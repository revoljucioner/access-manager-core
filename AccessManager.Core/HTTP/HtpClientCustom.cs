using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using AccessManager.Core.Extensions;
using AccessManager.Core.HTTP.Base;

namespace AccessManager.Core.HTTP
{
    public class HtpClientCustom
    {
        private readonly HttpClient _client;

        public HtpClientCustom(HttpClient client)
        {
            _client = client;
        }

        public async Task<CommonResponse<TResponse>> SendAsync<TRequest, TResponse>(RequestCustom<TRequest> request)
        {
            var httpRequest = new HttpRequestMessage
            {
                Content = request.Content == null ? null : new StringContent(JsonConvert.SerializeObject(request.Content), Encoding.UTF8, "application/json"),
                RequestUri = new Uri(request.RequestUri),
                Method = request.Method
            };

            if (!string.IsNullOrEmpty(request.Token))
            {
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", request.Token);
            }

            var response = await _client.SendAsync(httpRequest);

            var result = await response.ToCommonResponse<TResponse>();

            return result;
        }
    }
}
