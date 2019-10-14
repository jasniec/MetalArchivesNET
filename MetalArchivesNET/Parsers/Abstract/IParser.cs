namespace MetalArchivesNET.Parsers.Abstract
{
    interface IParser<T> where T : class, new()
    {
        T Parse(string content);
    }
}
