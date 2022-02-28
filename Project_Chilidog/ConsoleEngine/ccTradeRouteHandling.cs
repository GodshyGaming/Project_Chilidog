using System;

namespace Project_Chilidog.ConsoleEngine
{
    public static class ccTradeRouteHandling
    {
        #region Methods

        /// <summary>
        /// Creates a TradeRoute game object
        /// </summary>
        /// 
        /// <returns>
        /// The trade route that was created
        /// </returns>
        public static void CreateTradeRoute()
        {
            if (Program.GlobalSettlements.Count < 2)
            {
                Console.WriteLine("There aren't enough settlements for trade routes to go to! You need at least 2.");
                return;
            }

            TradeRoutes.ITradeRoute NewTradeRoute;
            
            BeginCreationMenu:
            Console.WriteLine("What type of trade route would you like to create?\n");
            Console.WriteLine("[1] Exit to Trade Routes Menu");
            Console.WriteLine("[2] Generic Trade Route");
            Console.Write("\nChilidog 0.01a> ");
            Console.WriteLine();

            switch (Console.ReadLine())
            {
                case "1":
                    break;
                #region Generic TradeRoute
                case "2":
                    string name;
                    string description;
                    Settlements.ISettlement destinationA;
                    Settlements.ISettlement destinationB;

                    Console.Write("What will this trade route be called?\n" +
                        "Name: ");
                    name = Console.ReadLine();
                    Console.Write("Describe this trade route for posterity\n" +
                        "Description: ");
                    description = Console.ReadLine();

                    #region destination assignment

                    BeginDestinationAssignment:
                    Console.WriteLine("Would you like to list the current settlements? [y] or [n]");
                    if (Console.ReadLine() == "y")
                        ccEngineFunctions.PrintGlobalList("GlobalSettlements");
                    Console.Write("What is the name of the first settlement you'd like to add?: ");
                    try
                    {
                        destinationA = ccEngineFunctions.SearchObject(Console.ReadLine(), Program.GlobalSettlements);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Couldn't find that settlement.");
                        goto BeginDestinationAssignment;
                    }
                    Console.Write("What is the name of the second settlement you'd like to add?: ");
                    try
                    {
                        destinationB = ccEngineFunctions.SearchObject(Console.ReadLine(), Program.GlobalSettlements);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Couldn't find that settlement.");
                        goto BeginDestinationAssignment;
                    }

                    #endregion

                    Console.WriteLine();

                    NewTradeRoute = new TradeRoutes.TradeRouteGeneric(
                        destinationA, destinationB, name, description
                        );
                    Console.WriteLine("{0} succesfully created!", name);
                    return;
                    #endregion
                default:
                    Console.WriteLine("I'm sorry I didn't quite catch that.");
                    goto BeginCreationMenu;
            }
        }

        /// <summary>
        /// Deletes a target trade route from the Global TradeRoutes list, thus destroying it
        /// </summary>
        /// 
        /// <param name="TargetName">
        /// string of name of trade route to be destroyed
        /// </param>
        /// 
        /// <returns>
        /// true if successful, false if not
        /// </returns>
        public static bool DestroyTradeRoute(string TargetName)
        {
            if (TargetName == null)
                return false;
            TradeRoutes.ITradeRoute? Target = null;
            foreach (var TradeRoute in Program.GlobalTradeRoutes)
            {
                if (TradeRoute.Name == TargetName)
                    Target = TradeRoute;
            }
            if (Target != null)
            {
                Program.GlobalTradeRoutes.Remove(Target);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Modifies the properties of a trade route
        /// </summary>
        /// 
        /// <param name="TargetName">
        /// String of name of trade route to be moified
        /// </param>
        /// 
        /// <returns>
        /// the modified trade route
        /// </returns>
        public static void ModifyTradeRoute(string TargetName)
        {
            TradeRoutes.ITradeRoute Target = null;
            string TargetProperty = "";

            if (TargetName == null)
                throw new ArgumentNullException("null value passed to ModifySettlement");

            foreach (var TradeRoute in Program.GlobalTradeRoutes)
            {
                if (TradeRoute.Name == TargetName)
                    Target = TradeRoute;
            }

            if (Target == null)
            {
                Console.WriteLine("Couldn't find a trade route of that name.");
                return;
            }

            #region Modify Menu

            ModifyMenuStart:
            ccEngineFunctions.PrintObject(Target);

            Console.Write("Type a property of {0} to modify or [Exit] to exit modification: ", Target.Name);
            TargetProperty = Console.ReadLine();

            if (TargetProperty == "Exit")
                return;

            foreach (var Property in Target.GetType().GetProperties())
            {
                if (Property.Name == TargetProperty)
                {
                    Console.WriteLine("{0}'s Current {1}: {2}",
                        Target.Name,
                        Property.Name,
                        Property.GetValue(Target)
                        );
                    Console.Write("What would you like the new {0} to be?: ", Property.Name);
                    Property.SetValue(Target, Console.ReadLine());
                    Console.WriteLine("{0}'s Current {1} has been updated to {2}",
                        Target.Name,
                        Property.Name,
                        Property.GetValue(Target)
                        );
                    goto ModifyMenuStart;
                }
            }

            Console.WriteLine("Couldn't find a property of that name.");
            goto ModifyMenuStart;

            #endregion

        }

        #endregion
    }
}
