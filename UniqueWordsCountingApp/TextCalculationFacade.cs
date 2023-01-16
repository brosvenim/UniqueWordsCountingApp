using UniqueWordsCountingApp.Logic;

namespace UniqueWordsCountingApp
{
    public class TextCalculationFacade : ITextCalculationFacade
    {
        private readonly IInputDataParser _parser;
        private readonly IWordsCalculator _calculator;

        public TextCalculationFacade(IInputDataParser parser,
                                     IWordsCalculator calculator)
        {
            _parser = parser;
            _calculator = calculator;
        }

        public async Task RunCalculation()
        {
            await _parser.ParseAndCountWordsInTextFileAsync();

            var resulsts = _calculator.GetMostCommonFirst(0, 5);

            foreach (var w in resulsts)
            {
                Console.WriteLine(w);
            }
        }
    }
}
