namespace AccessManager.Core.HTTP.Base
{
    public class RequestCustom<T>
    {
        public HttpMethod Method;

        public string RequestUri;

        public T? Content;

        public string? Token;
    }
}
