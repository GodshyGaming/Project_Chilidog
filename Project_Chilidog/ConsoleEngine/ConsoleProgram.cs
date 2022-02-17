using Project_Chilidog.Settlements;
using Project_Chilidog.Goods;
using Project_Chilidog.Merchants;
using Project_Chilidog.TradeRoutes;

namespace Project_Chilidog.ConsoleEngine
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
    static class Program
    {
        #region Fields

        #region Fields.GameObjects

        /// <summary>
        /// list of all settlements in the current worldspace
        /// </summary>
        public static List<ISettlement> GlobalSettlements = new List<ISettlement>();

        /// <summary>
        /// list of all merchants in the current worldspace
        /// </summary>
        public static List<IMerchant> GlobalMerchants = new List<IMerchant>();

        /// <summary>
        /// list of all trade routes in the current worldspace
        /// </summary>
        public static List<ITradeRoutes> GlobalTradeRoutes = new List<ITradeRoutes>();

        #endregion

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
                while (true)
                {
                    #region Main Menu

                    Console.WriteLine("\n----------Main Menu----------\n" +
                        "Select an option from the following:\n");
                    Console.WriteLine("[1] Save or Load your simulation");
                    Console.WriteLine();
                    Console.Write("Chilidog 0.01a> ");

                    #endregion
                    switch (Console.ReadLine())
                    {
                        #region Save/Load Menu
                        case "1":
                            while (true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("\n----------Save/Load----------\n" +
                                    "Select an option from the following:\n");
                                Console.WriteLine("[1] Load a simulation");
                                Console.WriteLine("[2] Save your simulation");
                                Console.WriteLine();
                                Console.Write("Chilidog 0.01a> ");
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        if (ccSaveLoad.Load())
                                            Console.WriteLine("Command Completed");
                                        else
                                            Console.WriteLine("Command Failed");
                                        break;
                                    case "2":
                                        if (ccSaveLoad.Save())
                                            Console.WriteLine("Command Completed");
                                        else
                                            Console.WriteLine("Command Failed");
                                        break;
                                    default:
                                        Console.WriteLine("I didn't quite catch that.");
                                        break;

                                }
                                break;
                            }
                            break;
                        #endregion
                        default:
                            Console.WriteLine("I didn't quite catch that.");
                            break;
                    }
                }
            }
        }

        #endregion
    }
}