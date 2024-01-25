namespace web.Models;
public class User 
{
    public string Name { get; init; }
    public IEnumerable<string> OwnedFiles { get; init; } = [];
}