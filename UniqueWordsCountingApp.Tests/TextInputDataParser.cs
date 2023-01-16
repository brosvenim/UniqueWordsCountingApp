using Microsoft.Extensions.Configuration;
using Moq;
using System.Text;
using UniqueWordsCountingApp.Infrastructure;
using UniqueWordsCountingApp.Logic;

namespace UniqueWordsCountingApp.Tests
{
    public class TextInputDataParser_Tests
    {
        [Fact]
        public async Task TextParser_Flow_Correct()
        {
            // Arrange
            var streamFacMock = new Mock<IStreamFactory>();
            streamFacMock.Setup(x => x.GetFileStream(It.IsAny<string>(), It.IsAny<FileMode>(), It.IsAny<FileAccess>()))
                .Returns(new MemoryStream(Encoding.UTF8.GetBytes("blah\nblah\nblah\n")));
            var configMock = new Mock<IConfiguration>();
            configMock.Setup(c => c["Settings:TextFilePath"]).Returns("pewpew");

            IInputDataReader dataReader = new TextFileInputDataReader(configMock.Object, streamFacMock.Object);

            WordsCalculator calculator = new WordsCalculator();

            TextInputDataParser parser = new TextInputDataParser(dataReader, calculator);

            // Act
            await parser.ParseAndCountWordsInTextFileAsync();

            var calculated = calculator.GetMostCommonFirst();

            // Assert
            Assert.Equal(3, calculated.First().Value);
        }
    }
}
