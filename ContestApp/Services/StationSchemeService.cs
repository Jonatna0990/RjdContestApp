using ContestApp.Models;
using Path = ContestApp.Models.Path;

namespace ContestApp.Services;
public class StationSchemeService
{
    public List<Point> Points { get; set; }
    public List<Segment> Segments { get; set; }
    public List<Path> Paths { get; set; }
    public List<Park> Parks { get; set; }

    public StationSchemeService() {
        // Пример точек
        Point point1 = new Point(0, 0);
        Point point2 = new Point(1, 0);
        Point point3 = new Point(1, 1);
        Point point4 = new Point(0, 1);

        Points = new List<Point> { point1, point2, point3, point4 };

        // Пример отрезков
        Segment segment1 = new Segment(point1, point2);
        Segment segment2 = new Segment(point2, point3);
        Segment segment3 = new Segment(point3, point4);
        Segment segment4 = new Segment(point4, point1);

        Segments = new List<Segment> { segment1, segment2, segment3, segment4 };

        // Пример путей
        Path path1 = new Path(new List<Segment> { segment1, segment2 });
        Path path2 = new Path(new List<Segment> { segment3, segment4 });

        Paths = new List<Path> { path1, path2 };

        // Пример парков
        Park park1 = new Park("Парк 1", new List<Path> { path1 });
        Park park2 = new Park("Парк 2", new List<Path> { path2 });

        Parks = new List<Park> { park1, park2 };
    }
}
