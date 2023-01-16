using Microsoft.Extensions.Configuration;
using Moq;
using System.Text;
using UniqueWordsCountingApp.Infrastructure;

namespace UniqueWordsCountingApp.Tests
{
    public class TextFileInputDataReader_Tests
    {
        [Fact]
        public async Task Number_Of_Rows_And_Contents_Correct()
        {
            // Arrange
            var streamFacMock = new Mock<IStreamFactory>();
            streamFacMock.Setup(x => x.GetFileStream(It.IsAny<string>(), It.IsAny<FileMode>(), It.IsAny<FileAccess>()))
                .Returns(new MemoryStream(Encoding.UTF8.GetBytes("blah\nblah\nblah\n")));
            var configMock = new Mock<IConfiguration>();
            configMock.Setup(c => c["Settings:TextFilePath"]).Returns("pewpew");

            IInputDataReader dataReader = new TextFileInputDataReader(configMock.Object, streamFacMock.Object);

            // Act
            var res = dataReader.ReadInputDataAsAsyncStreamAsync();

            // Assert
            int counter = 0;
            await foreach (var r in res)
            {
                counter++;
                Assert.Equal("blah", r);
            }

            Assert.Equal(3, counter);
        }
    }
}