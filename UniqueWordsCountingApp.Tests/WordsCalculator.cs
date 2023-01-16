using UniqueWordsCountingApp.Logic;

namespace UniqueWordsCountingApp.Tests
{
    public class WordsCalculator_Tests
    {
        [Fact]
        public void Calculations_Are_Correct()
        {
            // Arrange
            string testingLine = "some of few of inputs of few";

            // Act
            var calc = new WordsCalculator();

            calc.CountWordsInLine(testingLine);

            var empty = calc.GetCalculatedWordsPagination(0, 0);
            var first = calc.GetCalculatedWordsPagination(0, 1);
            var second = calc.GetCalculatedWordsPagination(1, 1);
            var ofEntry = calc.GetMostCommonFirst();
            var fewEntry = calc.GetMostCommonFirst(1, 1);

            //Assert 
            Assert.Empty(empty);
            Assert.Single(first);
            Assert.Single(second);
            Assert.Equal("of", ofEntry.First().Key);
            Assert.Equal("few", fewEntry.First().Key);
        }
    }
}
