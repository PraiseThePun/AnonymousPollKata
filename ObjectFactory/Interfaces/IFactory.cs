namespace ObjectFactory
{
    public interface IFactory<T>
    {
        T Parse(string rawString);
    }
}
