using UniqueWordsCountingApp.Infrastructure;

namespace UniqueWordsCountingApp.Logic
{
    public class TextInputDataParser : IInputDataParser
    {
        private readonly IInputDataReader _inputDataReader;
        private readonly IWordsCalculator _calculator;

        public TextInputDataParser(IInputDataReader inputDataReader,
                                   IWordsCalculator calculator)
        {
            _inputDataReader = inputDataReader;
            _calculator = calculator;
        }

        public async Task ParseAndCountWordsInTextFileAsync()
        {
            try
            {
                var rawInput = _inputDataReader.ReadInputDataAsAsyncStreamAsync();
                await foreach (var line in rawInput)
                {
                    if (!TryRemoveNonAlphaSymbols(line))
                        continue;
                    _calculator.CountWordsInLine(line);
                }
            }
            catch (ArgumentOutOfRangeException aore)
            {
                //logging goes here
                Console.WriteLine($"Failed to process. Line contains to many characters. For more information visit: {aore.HelpLink}");
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private unsafe bool TryRemoveNonAlphaSymbols(string line)
        {
            if (string.IsNullOrEmpty(line))
                return false;

            fixed (char* pLine = line)
            {
                char* p = pLine;
                for (int i = 0; i < line.Length; i++)
                {
                    // 65-90  97-122
                    // A - Z  a - z
                    if (*p < 'A' || (*p > 'Z' && *p < 'a') || *p > 'z')
                        *p = ' ';
                    // + 32
                    if (*p >= 'A' && *p <= 'Z')
                        *p = (char)(*p + 32);
                    p++;
                }
            }
            return true;
        }
    }
}
