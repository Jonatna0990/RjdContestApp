
namespace ContestApp.Models;

/// <summary>
/// Путь, состоящий из отрезков
/// </summary>
public class Path
{
    public List<Segment> Segments { get; set; }

    public Path(List<Segment> segments) {
        Segments = segments;
    }
}
