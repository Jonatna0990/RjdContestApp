using ContestApp.Models.Console;

namespace ContestApp.Services;

/// <summary>
/// Сервис для запуска команд
/// </summary>
internal class CommandRunnerService
{

    private List<IConsoleCommand> _commandsDictionary;

    public CommandRunnerService(List<IConsoleCommand> commands) {
        _commandsDictionary = commands;
    }

    public void Run() {
        while (true) {
            Listen();
        }
    }

    private void Listen() {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Доступные комманды:");
        Console.ResetColor();

        foreach (var command in _commandsDictionary) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{command.Command}:");
            Console.ResetColor();
            Console.Write($"{command.Name}");
            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine();
        Console.Write("Введите команду:");
        Console.ResetColor();

        string? inputCommand = Console.ReadLine();
        if (inputCommand != null) {
            inputCommand = inputCommand.Trim().ToLower();

            var commandKey = _commandsDictionary.Find(t => t.Command?.ToLower() == inputCommand);
            if (commandKey != null) {
                commandKey?.Run?.Invoke();
                Console.WriteLine();
                Listen();
            }
            else if (inputCommand == "exit")
                Environment.Exit(0);
            else {
                Console.WriteLine();
                Console.WriteLine("Команда не найдена");
                Console.WriteLine();
                Listen();
            }
        }
    }
}
