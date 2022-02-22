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
        public static Goods.IGood CreateGood()
        {
            Goods.IGood NewGood;
            while (true)
            {
                Console.WriteLine("What type of good would you like to create?\n");
                Console.WriteLine("[1] Generic Agricultural");
                Console.Write("\nChilidog 0.01a> ");
                Console.WriteLine();

                switch (Console.ReadLine())
                {
                    #region Agricultural Good
                    case "1":
                        string name;
                        string description;
                        string basicUnit;
                        decimal baseValue;
                        int expirationTime;

                        Console.Write("What will this agricultural good be called?\n" +
                            "Name: ");
                        name = Console.ReadLine();
                        Console.Write("Describe this agricultural good for posterity\n" +
                            "Description: ");
                        description = Console.ReadLine();
                        Console.Write("What will the basic unit of this agricultual" +
                            "product be known as? (kg, lb, bushel, whatever)\n" +
                            "Name: ");
                        basicUnit = Console.ReadLine();
                        Console.Write("What will be the basic value of this product, " +
                            "in decimals of your base currency, " +
                            "before any scarcity is calculated?\n" +
                            "Base Value: ");
                        baseValue = decimal.Parse(Console.ReadLine());
                        Console.Write("How long can this agricultural good last in days " +
                            "before expiring? -1 for non-perishables.\n" +
                            "Days before expiring: ");
                        expirationTime = int.Parse(Console.ReadLine());

                        Console.WriteLine();

                        NewGood = new Goods.GoodAgricultural(
                            name, description, basicUnit, baseValue, expirationTime
                            );
                        Console.WriteLine("{0} succesfully created!", name);
                        return NewGood;
                    #endregion
                    default:
                        Console.WriteLine("I'm sorry I didn't quite catch that.");
                        break;
                }
            }
        }

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

        #endregion
    }
}
