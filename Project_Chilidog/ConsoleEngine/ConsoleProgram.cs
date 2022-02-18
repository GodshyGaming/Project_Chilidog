using Project_Chilidog.Settlements;
using Project_Chilidog.Goods;
using Project_Chilidog.Merchants;
using Project_Chilidog.TradeRoutes;

using System;
using System.Collections.Generic;

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
        /// list of all goods in the current worldspace
        /// </summary>
        public static List<IGood> GlobalGoods = new List<IGood>();

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
        public static List<ITradeRoute> GlobalTradeRoutes = new List<ITradeRoute>();

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
                #region Main Menu

                Console.WriteLine("\n----------Main Menu----------\n" +
                    "Select an option from the following:\n");
                Console.WriteLine("[1] Save or Load your simulation");
                Console.WriteLine("[2] Go to your simulation");
                Console.WriteLine("[3] Work with goods");
                Console.WriteLine("[4] Work with settlements");
                Console.WriteLine("[5] Work with trade routes");
                Console.WriteLine("[6] Work with merchants");
                Console.WriteLine("[7] Exit Program");
                Console.Write("\nChilidog 0.01a> ");

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
                    #region Simulation Menu
                    case "2":
                        while (true)
                        {
                            Console.WriteLine("This menu is not implemented yet");
                            break;
                        }
                        break;
                    #endregion
                    #region Goods Menu
                    case "3":
                        while (true)
                        {
                            Console.WriteLine("\n----------Goods Menu----------\n" +
                                "Select an option from the following:\n");
                            Console.WriteLine("[1] Create a new good");
                            Console.Write("\nChilidog 0.01a> ");
                            switch(Console.ReadLine())
                            {
                                case "1":
                                    PrintObject(ccGoodHandling.CreateGood());
                                    PrintGlobalList("GlobalGoods");
                                    break;
                                default:
                                    Console.WriteLine("I didn't quite catch that.");
                                    break;
                            }
                            break;
                        }
                        Console.WriteLine();
                        break;
                    #endregion
                    #region Settlements Menu
                    case "4":
                        while (true)
                        {
                            Console.WriteLine("This menu is not implemented yet");
                            break;
                        }
                        break;
                    #endregion
                    #region Trade Routes Menu
                    case "5":
                        while (true)
                        {
                            Console.WriteLine("This menu is not implemented yet");
                            break;
                        }
                        break;
                    #endregion
                    #region Merchants Menu
                    case "6":
                        while (true)
                        {
                            Console.WriteLine("This menu is not implemented yet");
                            break;
                        }
                        break;
                    #endregion
                    #region Exit Prompt
                    case "7":
                        while (true)
                        {
                            Console.WriteLine("\nAre you sure you wish to exit? " +
                                "All unsaved progress will be lost.\n" +
                                "[y] to exit, [n] to return");
                            Console.Write("Chilidog 0.01a> ");
                            switch(Console.ReadLine())
                            {
                                case "y":
                                    Console.WriteLine("Very well, good bye.");
                                    Environment.Exit(0);
                                    break;
                                case "n":
                                    Console.WriteLine("Returning to main menu");
                                    goto ExitPromptReturn;
                                default:
                                    Console.WriteLine("I didn't quite catch that.");
                                    break;
                            }

                        }
                        ExitPromptReturn:
                        break;
                    #endregion
                    default:
                        Console.WriteLine("I didn't quite catch that.");
                        break;
                }
            }
        }

        /// <summary>
        /// Prints an object's parameters to console, including all types of game objects
        /// </summary>
        /// 
        /// <param name="obj">
        /// Any object, but preferrably an IGood, ISettlement, IMerchant, or ITradeRoute descendant
        /// </param>
        static void PrintObject(object obj)
        {
            Type type = obj.GetType();
            foreach (var info in type.GetProperties())
            {
                Console.WriteLine(
                    "{0}: {1}",
                    info.Name,
                    obj.GetType().GetProperty(info.Name).GetValue(obj, null)
                    );
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Prints out one of the Global Lists by name
        /// </summary>
        /// 
        /// <param name="listName">
        /// the name as a string of the list to print
        /// </param>
        static void PrintGlobalList(string listName)
        {
            switch(listName)
            {
                case "GlobalGoods":
                    Console.WriteLine("Global Goods List:");
                    foreach (var Good in GlobalGoods)
                        Console.WriteLine(Good.Name);
                    break;
                case "GlobalSettlements":
                    Console.WriteLine("Global Settlements List:");
                    foreach (var Settlement in GlobalSettlements)
                        Console.WriteLine(Settlement.Name);
                    break;
                case "GlobalMerchants":
                    Console.WriteLine("Global Merchants List:");
                    foreach (var Merchant in GlobalMerchants)
                        Console.WriteLine(Merchant.Name);
                    break;
                case "GlobalTradeRoutes":
                    Console.WriteLine("Global Trade Routes List:");
                    foreach (var TradeRoute in GlobalTradeRoutes)
                        Console.WriteLine(TradeRoute.Name);
                    break;
                default:
                    throw new ArgumentException("listName is not a valid list name");
            }
            Console.WriteLine();
        }

        #endregion
    }
}