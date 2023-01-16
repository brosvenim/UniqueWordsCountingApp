namespace UniqueWordsCountingApp.Infrastructure
{
    public interface IStreamFactory
    {
        Stream GetFileStream(string path, FileMode mode, FileAccess access);
    }
}