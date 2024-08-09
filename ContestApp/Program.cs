using ContestApp.Commands;
using ContestApp.Models.Console;
using ContestApp.Services;

namespace ContestApp
{
    internal class Program
    {
        #region Init
        private static List<IConsoleCommand> commands = new() {
            new FillParkCommand(),
            new ShortestPathCommand(),
            new ShowAllParksCommand()
        };
        
        #endregion

        static void Main(string[] args)
        {
            new CommandRunnerService(commands).Run();
        }
    }
}