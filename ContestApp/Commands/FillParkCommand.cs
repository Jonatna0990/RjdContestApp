using ContestApp.Models.Console;
using ContestApp.Services;

namespace ContestApp.Commands;
public class FillParkCommand : IConsoleCommand
{
    public string? Name { get; set; }
    public string? Command { get; set; }
    public Action? Run { get; set; }

    public FillParkCommand() {
        Name = "Заливка парка";
        Command = "fp";
        Run = FillPark;
    }

    private void FillPark() {
        try {
            StationSchemeService stationSchemeService = new StationSchemeService();

            Console.WriteLine("Доступные парки:");
            for (var index = 0; index < stationSchemeService.Parks.Count; index++) {
                var park = stationSchemeService.Parks[index];
                Console.WriteLine($"{index})Парк: {park.Name}");
            }

            Console.WriteLine("Выберите порядковый номер парка для заливки:");
            int parkIndex = int.Parse(Console.ReadLine());

            if (parkIndex < 0 || parkIndex < stationSchemeService.Parks.Count) {
                ParkService.FillPark(stationSchemeService.Parks[parkIndex]);
            }
            else {
                Console.WriteLine("Парк не найден:");
            }
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }
}
