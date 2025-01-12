namespace ParsingService.Application.Interfaces;

public interface IParsersContainer
{
    public void RegisterParser(IParser parser);
    public IEnumerable<IParser> GetParsers();
    public void RunParsers();
}