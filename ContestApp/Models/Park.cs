namespace ContestApp.Models;

/// <summary>
/// Парк, представленный набором путей
/// </summary>
public class Park
{
    public string Name { get; set; }
    public List<Path> Paths { get; set; }

    public Park(string name, List<Path> paths) {
        Name = name;
        Paths = paths;
    }
}
