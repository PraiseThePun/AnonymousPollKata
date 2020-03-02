namespace TextLoaderFactory
{
    public abstract class ObjectParser<T> where T : ReadableObject
    {
        public abstract T ReadToObject(string text);
    }
}
