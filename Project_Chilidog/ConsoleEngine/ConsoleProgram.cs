using Project_Chilidog.Settlements;
using Project_Chilidog.Goods;
using Project_Chilidog.Merchants;
using Project_Chilidog.TradeRoutes;

namespace ConsoleEngine
{
    /// <summary>
    /// Entrypoint for console version of program
    /// </summary>
    ///
    /// <methods>
    /// Main();
    ///     Entrypoint for console version of program
    /// </methods>
    class Program
    {
        /// <summary>
        /// Entrypoint for console version of program
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Welcome to Project Chilidog");
            while (true)
            {
                string? command;

                Console.Write("Chilidog 0.01a> ");
                command = Console.ReadLine();
                if (command == null)
                    throw new Exception("Error: Null Line");
                else if (command == "")
                    Console.WriteLine("You have to say something for me to know what you want");
                Console.WriteLine(command);
            }
        }
    }
}