using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Chilidog.ConsoleEngine
{
    public static class ccEngineFunctions
    {

        /// <summary>
        /// Prints an object's parameters to console, including all types of game objects
        /// </summary>
        /// 
        /// <param name="obj">
        /// Any object, but preferrably an IGood, ISettlement, IMerchant, or ITradeRoute descendant
        /// </param>
        public static void PrintObject(object obj)
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
        public static void PrintGlobalList(string listName)
        {
            switch (listName)
            {
                case "GlobalGoods":
                    Console.WriteLine("Global Goods List:");
                    foreach (var Good in Program.GlobalGoods)
                        Console.WriteLine(Good.Name);
                    break;
                case "GlobalSettlements":
                    Console.WriteLine("Global Settlements List:");
                    foreach (var Settlement in Program.GlobalSettlements)
                        Console.WriteLine(Settlement.Name);
                    break;
                case "GlobalMerchants":
                    Console.WriteLine("Global Merchants List:");
                    foreach (var Merchant in Program.GlobalMerchants)
                        Console.WriteLine(Merchant.Name);
                    break;
                case "GlobalTradeRoutes":
                    Console.WriteLine("Global Trade Routes List:");
                    foreach (var TradeRoute in Program.GlobalTradeRoutes)
                        Console.WriteLine(TradeRoute.Name);
                    break;
                default:
                    throw new ArgumentException("listName is not a valid list name");
            }
            Console.WriteLine();
        }
    }
}
