namespace UniqueWordsCountingApp.Extensions
{
    public static class StringExtensions
    {
        public static IEnumerable<(string key, int count)> GroupAndCountEntries(this string line)
        {
            if (string.IsNullOrEmpty(line))
                throw new ArgumentNullException(nameof(line));

            return line.ToLowerInvariant()
                   .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).GroupBy(s => s).Select(e => (e.Key, e.Count()));

        }
    }
}
