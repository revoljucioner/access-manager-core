namespace AccessManager.Core.Collections
{
    internal class RetentionDictionaryItem<T>
    {
        public DateTimeOffset CreateDateTime { get; set; }
        public T Value { get; set; }
    }
}
