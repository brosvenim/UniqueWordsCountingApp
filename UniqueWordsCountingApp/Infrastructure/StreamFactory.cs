namespace UniqueWordsCountingApp.Infrastructure
{
    public class StreamFactory : IStreamFactory
    {
        public Stream GetFileStream(string path, FileMode mode, FileAccess access) => new FileStream(path, mode, access);
    }
}
