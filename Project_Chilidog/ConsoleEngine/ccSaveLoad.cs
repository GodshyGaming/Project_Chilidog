using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace Project_Chilidog.ConsoleEngine
{
    public static class ccSaveLoad
    {
        #region Methods

        /// <summary>
        /// Saves the _globalX lists to json files
        /// </summary>
        public static bool Save()
        {
            SaveStart:
            Console.WriteLine("What would you like your save file to be called?: ");
            string filename = Program.SaveFolder + "\\" + Console.ReadLine();

            if (Directory.Exists(filename))
            {
                Console.WriteLine("The filename you specified is already in use, would you like to overwrite it? [y] or [n]");
                Console.Write("\nChilidog 0.01a> ");
                if (Console.ReadLine() == "y")
                    goto SaveContinue;
                goto SaveStart;
            }
            else
            {
                Directory.CreateDirectory(filename);
            }

            SaveContinue:

            File.WriteAllText(filename + "\\GlobalGoods.json", JsonSerializer.Serialize(Program.GlobalGoods));
            File.WriteAllText(filename + "\\GlobalSettlements.json", JsonSerializer.Serialize(Program.GlobalSettlements));
            File.WriteAllText(filename + "\\GlobalMerchants.json", JsonSerializer.Serialize(Program.GlobalMerchants));
            File.WriteAllText(filename + "\\GlobalTradeRoutes.json", JsonSerializer.Serialize(Program.GlobalTradeRoutes));

            return true;
        }

        /// <summary>
        /// loads the _globalX lists from json files
        /// </summary>
        public static bool Load()
        {
            var SaveDirectory = new DirectoryInfo(Program.SaveFolder);
            LoadStart:
            Console.WriteLine("Current Save Files: ");
            foreach (var save in SaveDirectory.EnumerateDirectories())
                Console.WriteLine(save.Name);
            Console.WriteLine("");
            Console.WriteLine("What save would you like to load?: ");
            string filename = Program.SaveFolder + Console.ReadLine();
            if (!Directory.Exists(filename))
            {
                Console.WriteLine("That save doesn't exist, did you mistype it?");
                goto LoadStart;
            }

            Program.GlobalGoods = JsonSerializer.Deserialize<List<Goods.IGood>>(File.ReadAllText(filename + "\\GlobalGoods.json"));
            Program.GlobalSettlements = JsonSerializer.Deserialize<List<Settlements.ISettlement>>(File.ReadAllText(filename + "\\GlobalSettlements.json"));
            Program.GlobalMerchants = JsonSerializer.Deserialize<List<Merchants.IMerchant>>(File.ReadAllText(filename + "\\GlobalMerchants.json"));
            Program.GlobalTradeRoutes = JsonSerializer.Deserialize<List<TradeRoutes.ITradeRoute>>(File.ReadAllText(filename + "\\GlobalTradeRoutes.json"));

            return true;
        }

        #endregion
    }
}
