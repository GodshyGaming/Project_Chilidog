using System;

namespace Project_Chilidog.ConsoleEngine
{
    public static class ccSettlementHandling
    {
        #region Methods

        /// <summary>
        /// Creates a settlement game object
        /// </summary>
        /// 
        /// <returns>
        /// The settlement that was created
        /// </returns>
        public static void CreateSettlement()
        {
            Settlements.ISettlement NewSettlement;

            BeginCreationMenu:
            Console.WriteLine("What type of settlement would you like to create?\n");
            Console.WriteLine("[1] Exit to Settlement Menu");
            Console.WriteLine("[2] Generic Settlement");
            Console.Write("\nChilidog 0.01a> ");
            Console.WriteLine();

            switch (Console.ReadLine())
            {
                case "1":
                    break;
                #region Generic Settlement
                case "2":
                    string name;
                    string description;
                    int population;

                    Console.Write("What will this settlement be called?\n" +
                        "Name: ");
                    name = Console.ReadLine();
                    Console.Write("Describe this settlement for posterity\n" +
                        "Description: ");
                    description = Console.ReadLine();
                    Console.Write("What will be the population of this settlement?\n" +
                        "Population: ");
                    population = int.Parse(Console.ReadLine());

                    Console.WriteLine();

                    NewSettlement = new Settlements.SettlementGeneric(
                        name, description, population
                        );
                    Console.WriteLine("{0} succesfully created!", name);
                    break;
                #endregion
                default:
                    Console.WriteLine("I'm sorry I didn't quite catch that.");
                    goto BeginCreationMenu;
            }
        }

        /// <summary>
        /// Deletes a target settlement from the Global Settlements list, thus destroying it
        /// </summary>
        /// 
        /// <param name="TargetName">
        /// string of name of settlement to be destroyed
        /// </param>
        /// 
        /// <returns>
        /// true if successful, false if not
        /// </returns>
        public static bool DestroySettlement(string TargetName)
        {
            if (TargetName == null)
                return false;
            Settlements.ISettlement? Target = null;
            foreach (var Settlement in Program.GlobalSettlements)
            {
                if (Settlement.Name == TargetName)
                    Target = Settlement;
            }
            if (Target != null)
            {
                Program.GlobalSettlements.Remove(Target);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Modifies the properties of a settlement
        /// </summary>
        /// 
        /// <param name="TargetName">
        /// String of name of settlement to be moified
        /// </param>
        /// 
        /// <returns>
        /// the modified settlement
        /// </returns>
        public static void ModifySettlement(string TargetName)
        {
            Settlements.ISettlement Target = null;
            string TargetProperty = "";

            if (TargetName == null)
                throw new ArgumentNullException("null value passed to ModifySettlement");

            foreach (var Settlement in Program.GlobalSettlements)
            {
                if (Settlement.Name == TargetName)
                    Target = Settlement;
            }

            if (Target == null)
            {
                Console.WriteLine("Couldn't find a good of that name.");
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
