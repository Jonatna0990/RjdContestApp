using ContestApp.Models;
using ContestApp.Models.Console;
using ContestApp.Services;

namespace ContestApp.Commands;
public class ShortestPathCommand : IConsoleCommand
{
    public string? Name { get; set; }
    public string? Command { get; set; }
    public Action? Run { get; set; }

    public ShortestPathCommand() {
        Name = "Поиск кратчайшего пути";
        Command = "sp";
        Run = FindShortestPathCommand;
    }

    private void FindShortestPathCommand() {

        try {
            // Создание схемы станции
            StationSchemeService stationSchemeService = new StationSchemeService();

            // Создание графа и добавление рёбер
            GraphService graph = new GraphService();
            foreach (var path in stationSchemeService.Paths) {
                for (int i = 0; i < path.Segments.Count - 1; i++) {
                    graph.AddEdge(path.Segments[i], path.Segments[i + 1], 1);
                }
            }

            // Ввод начального и конечного отрезков
            Console.WriteLine("Введите номер начального отрезка:");
            int startSegmentIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите номер конечного отрезка:");
            int endSegmentIndex = int.Parse(Console.ReadLine());

            Segment startSegment = stationSchemeService.Segments[startSegmentIndex];
            Segment endSegment = stationSchemeService.Segments[endSegmentIndex];

            // Поиск кратчайшего пути
            List<Segment> shortestPath = graph.FindShortestPath(startSegment, endSegment);

            if (shortestPath != null) {
                Console.WriteLine("Кратчайший путь:");
                foreach (var segment in shortestPath) {
                    Console.WriteLine($"Отрезок от ({segment.StartPoint.X}, {segment.StartPoint.Y}) до ({segment.EndPoint.X}, {segment.EndPoint.Y})");
                }
            }
            else {
                Console.WriteLine("Путь не найден.");
            }
        }
        catch (Exception e) {
            Console.WriteLine(e);
        }
       
    }
}
