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
                        GoodsMenuStart:
                        Console.WriteLine("\n----------Goods Menu----------\n" +
                            "Select an option from the following:\n");
                        Console.WriteLine("[1] Create a new good");
                        Console.WriteLine("[2] Delete an old good");
                        Console.WriteLine("[3] Modify a good");
                        Console.WriteLine("[4] View current goods");
                        Console.WriteLine("[5] Examine a good");
                        Console.WriteLine("[6] Return to main men");
                        Console.Write("\nChilidog 0.01a> ");
                        switch(Console.ReadLine())
                        {
                            case "1":
                                ccGoodHandling.CreateGood();
                                ccEngineFunctions.PrintGlobalList("GlobalGoods");
                                goto GoodsMenuStart;
                            case "2":
                                Console.WriteLine("Please enter the name of the item you wish to delete:");
                                if (ccGoodHandling.DestroyGood(Console.ReadLine()))
                                    Console.WriteLine("Item Successfully Deleted!");
                                else
                                    Console.WriteLine("Item not found");
                                ccEngineFunctions.PrintGlobalList("GlobalGoods");
                                goto GoodsMenuStart;
                            case "3":
                                Console.WriteLine("What good would you like to modify?: ");
                                ccGoodHandling.ModifyGood(Console.ReadLine());
                                goto GoodsMenuStart;
                            case "4":
                                ccEngineFunctions.PrintGlobalList("GlobalGoods");
                                goto GoodsMenuStart;
                            case "5":
                                Console.Write("What good would you like to examine?: ");
                                string SearchTarget = Console.ReadLine();
                                foreach (var Good in GlobalGoods)
                                    if (Good.Name == SearchTarget)
                                        ccEngineFunctions.PrintObject(Good);
                                goto GoodsMenuStart;
                            case "6":
                                break;
                            default:
                                Console.WriteLine("I didn't quite catch that.");
                                goto GoodsMenuStart;
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

        #endregion
    }
}