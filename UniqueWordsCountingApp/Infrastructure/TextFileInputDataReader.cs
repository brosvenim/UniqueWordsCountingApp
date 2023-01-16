using Microsoft.Extensions.Configuration;

namespace UniqueWordsCountingApp.Infrastructure
{
    public class TextFileInputDataReader : IInputDataReader
    {
        private readonly IConfiguration _configuration;
        private readonly IStreamFactory _fac;

        public TextFileInputDataReader(IConfiguration configuration, IStreamFactory fac)
        {
            _configuration = configuration;
            _fac = fac;
        }

        public async IAsyncEnumerable<string> ReadInputDataAsAsyncStreamAsync()
        {
            using var fileStream = _fac.GetFileStream(_configuration["Settings:TextFilePath"], FileMode.Open, FileAccess.Read);
            using var reader = new StreamReader(fileStream);
            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
                yield return line;
        }
    }
}
