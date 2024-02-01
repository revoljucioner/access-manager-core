using System.Net;

namespace AccessManager.Core.Extensions
{
    public static class HttpStatusCodeExtension
    {
        public static string GetReasonPhrase(this HttpStatusCode status)
        {
            var m = new HttpResponseMessage(HttpStatusCode.NotModified);
            string desc = m.ReasonPhrase;

            return desc;
        }
    }
}
