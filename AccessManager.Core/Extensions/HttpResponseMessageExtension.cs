using AccessManager.Core.HTTP.Base;
using Newtonsoft.Json;
using System.Net;

namespace AccessManager.Core.Extensions
{
    public static class HttpResponseMessageExtension
    {
        public static async Task<CommonResponse<T>> ToCommonResponse<T>(this HttpResponseMessage message)
        {
            var content = await message.Content.ReadAsStringAsync();

            var commonResponse = new CommonResponse<T>
            {
                ErrorMessage = message.IsSuccessStatusCode ? null : content,
                StatusCode = message.StatusCode,
                Content = content,
                IsSuccesfull = message.IsSuccessStatusCode,
                Headers = message.Headers.ToDictionary(a => a.Key, a => a.Value)
            };

            try
            {
                if (typeof(T) == typeof(string))
                {
                    commonResponse.Body = (T)Convert.ChangeType(content, typeof(T));
                }
                else
                {
                    commonResponse.Body = JsonConvert.DeserializeObject<T>(content);
                }
            }
            catch (JsonReaderException e) { }
            catch (JsonSerializationException e)
            {

            }
            return commonResponse;
        }

        public static async Task<CommonResponse<T>> ThrowIfNotTargetStatus<T>(this Task<CommonResponse<T>> response, HttpStatusCode expectedStatusCode)
        {
            var result = await response;
            if (result.StatusCode != expectedStatusCode)
            {
                throw new Exception($"Status code is {result.StatusCode} but should be {expectedStatusCode}");
            }
            return result;
        }
    }
}
