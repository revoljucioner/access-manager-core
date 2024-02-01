using System.Net;

namespace AccessManager.Core.HTTP.Base
{
    public class CommonResponse<T>
    {
        public T Body { get; set; }
        public string ErrorMessage { get; set; }
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccesfull { get; set; }
        public Dictionary<string, IEnumerable<string>> Headers { get; set; }
    }
}
