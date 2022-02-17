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
    /// <fields>
    /// _globalSettlements: list of all settlements in the current worldspace
    /// _globalMerchants: list of all merchants in the current worldspace
    /// _globalTradeRoutes: list of all trade routes in the current worldspace
    /// </fields>
    /// 
    /// <methods>
    /// Main();
    ///     Entrypoint for console version of program
    /// </methods>
    class Program
    {
        #region Fields

        /// <summary>
        /// list of all settlements in the current worldspace
        /// </summary>
        private List<ISettlement> _globalSettlements = new List<ISettlement>();

        /// <summary>
        /// list of all merchants in the current worldspace
        /// </summary>
        private List<IMerchant> _globalMerchants = new List<IMerchant>();

        /// <summary>
        /// list of all trade routes in the current worldspace
        /// </summary>
        private List<ITradeRoutes> _globalTradeRoutes = new List<ITradeRoutes>();

        #endregion

        #region Methods

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

        #endregion
    }
}