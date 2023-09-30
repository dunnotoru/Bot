namespace Bot.Interfaces
{
    internal interface IHtmlParser
    {
        Task<string> ParseAsync(string text);
    }
}
