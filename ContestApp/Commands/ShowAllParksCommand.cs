using ContestApp.Models.Console;
using ContestApp.Services;

namespace ContestApp.Commands;
public class ShowAllParksCommand : IConsoleCommand
{
    public string? Name { get; set; }
    public string? Command { get; set; }
    public Action? Run { get; set; }

    public ShowAllParksCommand() {
        Name = "Показать все парки";
        Command = "sap";
        Run = ShowAllParks;
    }

    private void ShowAllParks() {
        StationSchemeService stationSchemeService = new StationSchemeService();

        Console.WriteLine("Доступные парки:");
        foreach (var park in stationSchemeService.Parks) {
            Console.WriteLine($"Парк: {park.Name}");
            foreach (var path in park.Paths) {
                foreach (var segment in path.Segments) {
                    Console.WriteLine($"Отрезок от ({segment.StartPoint.X}, {segment.StartPoint.Y}) до ({segment.EndPoint.X}, {segment.EndPoint.Y})");
                }
            }
        }
    }
}
