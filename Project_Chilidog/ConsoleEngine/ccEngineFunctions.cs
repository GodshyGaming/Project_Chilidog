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
            foreach (var Property in type.GetProperties())
            {
                Console.WriteLine(
                    "{0}: {1}",
                    Property.Name,
                    Property.GetValue(obj, null)
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

        /// <summary>
        /// searches for an object by name in one of the Program global lists
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// Whatever type the item you're looking for it. Populated from type of list searched
        /// </typeparam>
        /// 
        /// <param name="searchTerm">
        /// name of the object you are searching for
        /// </param>
        /// <param name="GlobalList">
        /// the list you are searching in, one of the global lists in Program
        /// </param>
        /// 
        /// <returns>
        /// The object you're looking for, hopefully
        /// </returns>
        /// 
        /// <exception cref="ArgumentException">
        /// If search couldn't be completed succesfully.
        /// </exception>
        public static IGameObject SearchObject(string searchTerm, List<IGameObject> GlobalList)
        {
            foreach(IGameObject GameObject in GlobalList)
            {
                if (GameObject.Name == searchTerm)
                    return GameObject;
            }
            throw new ArgumentException("Search term could not be found");
        }
    }
}
