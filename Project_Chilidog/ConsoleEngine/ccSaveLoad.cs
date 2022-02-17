namespace Project_Chilidog.ConsoleEngine
{
    public static class ccSaveLoad
    {
        #region Methods

        /// <summary>
        /// Saves the _globalX lists to a json file
        /// </summary>
        public static bool Save(
            List<Settlements.ISettlement> GlobalSettlements,
            List<Merchants.IMerchant> GlobalMerchants,
            List<TradeRoutes.ITradeRoutes> GlobalTradeRoutes
            )
        {
            Console.WriteLine("Not implemented");
            return true;
        }

        /// <summary>
        /// loads the _globalX lists from a json file
        /// </summary>
        public static bool Load(
            List<Settlements.ISettlement> GlobalSettlements,
            List<Merchants.IMerchant> GlobalMerchants,
            List<TradeRoutes.ITradeRoutes> GlobalTradeRoutes
            )
        {
            Console.WriteLine("Not implemented");
            return true;
        }

        #endregion
    }
}
