namespace UniqueWordsCountingApp.Logic
{
    public interface IInputDataParser
    {
        Task ParseAndCountWordsInTextFileAsync();
    }
}