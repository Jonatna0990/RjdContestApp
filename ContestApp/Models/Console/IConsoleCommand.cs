namespace ContestApp.Models.Console;
/// <summary>
/// Интерфейс для запуска команд
/// </summary>
internal interface IConsoleCommand
{
    public string? Name { get; set; }
    public string? Command { get; set; }
    public Action? Run { get; set; }
}
