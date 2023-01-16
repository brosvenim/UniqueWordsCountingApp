namespace UniqueWordsCountingApp.Infrastructure
{
    public interface IInputDataReader
    {
        IAsyncEnumerable<string> ReadInputDataAsAsyncStreamAsync();
    }
}