using System;

namespace Project_Chilidog.ConsoleEngine
{
    public static class ccGoodHandling
    {
        #region Methods

        /// <summary>
        /// Creates a Good game object
        /// </summary>
        /// 
        /// <returns>
        /// The good that was created
        /// </returns>
        public static void CreateGood()
        {
            Goods.IGood NewGood;
            
            BeginCreationMenu:
            Console.WriteLine("What type of good would you like to create?\n");
            Console.WriteLine("[1] Exit to Goods Menu");
            Console.WriteLine("[2] Generic Good");
            Console.Write("\nChilidog 0.01a> ");
            Console.WriteLine();

            switch (Console.ReadLine())
            {
                case "1":
                    break;
                #region Generic Good
                case "2":
                    string name;
                    string description;
                    string basicUnit;
                    decimal baseValue;

                    Console.Write("What will this good be called?\n" +
                        "Name: ");
                    name = Console.ReadLine();
                    Console.Write("Describe this good for posterity\n" +
                        "Description: ");
                    description = Console.ReadLine();
                    Console.Write("What will the basic unit of this" +
                        "good be known as? (kg, lb, bushel, whatever)\n" +
                        "Name: ");
                    basicUnit = Console.ReadLine();
                    Console.Write("What will be the basic value of this good, " +
                        "in decimals of your base currency, " +
                        "before any scarcity is calculated?\n" +
                        "Base Value: ");
                    baseValue = decimal.Parse(Console.ReadLine());

                    Console.WriteLine();

                    NewGood = new Goods.GoodGeneric(
                        name, description, basicUnit, baseValue
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
        /// Deletes a target good from the Global Goods list, thus destroying it
        /// </summary>
        /// 
        /// <param name="TargetName">
        /// string of name of good to be destroyed
        /// </param>
        /// 
        /// <returns>
        /// true if successful, false if not
        /// </returns>
        public static bool DestroyGood(string TargetName)
        {
            if (TargetName == null)
                return false;
            Goods.IGood? Target = null;
            foreach (var Good in Program.GlobalGoods)
            {
                if (Good.Name == TargetName)
                    Target = Good;
            }
            if (Target != null)
            {
                Program.GlobalGoods.Remove(Target);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Modifies the properties of a good
        /// </summary>
        /// 
        /// <param name="TargetName">
        /// String of name of good to be moified
        /// </param>
        /// 
        /// <returns>
        /// the modified good
        /// </returns>
        public static Goods.IGood ModifyGood(string TargetName)
        {
            Goods.IGood Target = null;
            string TargetProperty = "";

            if (TargetName == null)
                return null;

            foreach (var Good in Program.GlobalGoods)
            {
                if (Good.Name == TargetName)
                    Target = Good;
            }

            if (Target == null)
            {
                Console.WriteLine("Couldn't find a good of that name.");
                return null;
            }

            #region Modify Menu

            ModifyMenuStart:
            ccEngineFunctions.PrintObject(Target);

            Console.Write("Type a property of {0} to modify or [Exit] to exit modification: ", Target.Name);
            TargetProperty = Console.ReadLine();

            if (TargetProperty == "Exit")
                return Target;

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
