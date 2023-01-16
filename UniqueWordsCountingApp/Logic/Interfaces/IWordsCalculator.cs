namespace UniqueWordsCountingApp.Logic
{
    public interface IWordsCalculator
    {
        void CountWordsInLine(string line);
        IEnumerable<KeyValuePair<string, int>> GetCalculatedWordsPagination(int skip, int take);
        IEnumerable<KeyValuePair<string, int>> GetMostCommonFirst(int skip, int take);
        IEnumerable<KeyValuePair<string, int>> GetMostCommonFirst();
    }
}