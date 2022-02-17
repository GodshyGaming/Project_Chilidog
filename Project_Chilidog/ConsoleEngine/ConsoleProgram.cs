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
    /// _commandList: dictionary to map all command strings to command methods
    /// </fields>
    /// 
    /// <methods>
    /// Main();
    ///     Entrypoint for console version of program
    /// </methods>
    class Program
    {
        #region Fields

        #region Fields.GameObjects

        /// <summary>
        /// list of all settlements in the current worldspace
        /// </summary>
        private static List<ISettlement> _globalSettlements = new List<ISettlement>();

        /// <summary>
        /// list of all merchants in the current worldspace
        /// </summary>
        private static List<IMerchant> _globalMerchants = new List<IMerchant>();

        /// <summary>
        /// list of all trade routes in the current worldspace
        /// </summary>
        private static List<ITradeRoutes> _globalTradeRoutes = new List<ITradeRoutes>();

        #endregion

        #region Fields.Dictionaries

        /// <summary>
        /// dictionary to map all command strings to command methods
        /// </summary>
        private static Dictionary<
            string,
            Func<List<ISettlement>, List<IMerchant>, List<ITradeRoutes>, bool>
            >
            _commandList_SaveLoad = new Dictionary<
            string,
            Func<List<ISettlement>, List<IMerchant>, List<ITradeRoutes>, bool>
            >()
        {
            { "Load", (
                _globalSettlements,
                _globalMerchants,
                _globalTradeRoutes
                )
                    => ccSaveLoad.Load(
                        _globalSettlements,
                        _globalMerchants,
                        _globalTradeRoutes
                        ) 
            },
            { "Save", (
                _globalSettlements,
                _globalMerchants,
                _globalTradeRoutes
                )
                    => ccSaveLoad.Save(
                        _globalSettlements,
                        _globalMerchants,
                        _globalTradeRoutes
                        )
            },
        };

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
                string? command;

                Console.Write("Chilidog 0.01a> ");
                command = Console.ReadLine();
                if (command == null)
                    throw new Exception("Error: Null Line");
                else if (command == "")
                    Console.WriteLine(
                        "You have to say something for me to know what you want"
                        );
                Console.WriteLine(command);
                foreach(var key in _commandList_SaveLoad.Keys)
                {
                    if (key == command)
                    {
                        if (_commandList_SaveLoad[key](
                            _globalSettlements,
                            _globalMerchants,
                            _globalTradeRoutes
                            ))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Command failed to execute");
                            break;
                        }
                    }
                }
            }
        }

        #endregion
    }
}