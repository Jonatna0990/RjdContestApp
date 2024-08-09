using ContestApp.Models;

namespace ContestApp.Services;
public class ParkService
{
    //Заливка парка
    public static void FillPark(Park park) {
        Console.WriteLine($"Заливка {park.Name}:");
        foreach (var path in park.Paths) {
            foreach (var segment in path.Segments) {
                Console.WriteLine($"Отрезок от ({segment.StartPoint.X}, {segment.StartPoint.Y}) до ({segment.EndPoint.X}, {segment.EndPoint.Y})");
            }
        }
    }
}
