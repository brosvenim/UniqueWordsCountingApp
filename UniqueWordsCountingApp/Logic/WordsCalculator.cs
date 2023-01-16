using System.Collections.Concurrent;
using UniqueWordsCountingApp.Extensions;

namespace UniqueWordsCountingApp.Logic
{
    public class WordsCalculator : IWordsCalculator
    {
        private readonly ConcurrentDictionary<string, int> _wordCount;

        public WordsCalculator()
        {
            _wordCount = new ConcurrentDictionary<string, int>();
        }

        public void CountWordsInLine(string line)
        {
            foreach (var (key, count) in line.GroupAndCountEntries())
            {
                _wordCount.AddOrUpdate(key, count, (k, v) => v + count);
            }
        }

        // Few methods for fun and test runs

        public IEnumerable<KeyValuePair<string, int>> GetCalculatedWordsPagination(int skip, int take)
        {
            return _wordCount.Skip(skip).Take(take);
        }

        public IEnumerable<KeyValuePair<string, int>> GetMostCommonFirst()
        {
            return _wordCount.OrderByDescending(kvp => kvp.Value);
        }

        public IEnumerable<KeyValuePair<string, int>> GetMostCommonFirst(int skip, int take)
        {
            return _wordCount.OrderByDescending(kvp => kvp.Value).Skip(skip).Take(take);
        }
    }
}
