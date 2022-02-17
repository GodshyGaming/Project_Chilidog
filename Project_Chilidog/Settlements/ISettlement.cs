﻿namespace Project_Chilidog.Settlements
{
    /// <title>
    /// ISettlement interface
    /// </title>
    /// 
    /// <summary>
    /// Determines basic behavior for settlement objects.
    /// </summary>
    /// 
    /// <fields>
    /// Name: The name of the settlement.
    /// Description: The description of the settlement.
    /// Population: Population of the settlement
    /// LocalTradeRoutes: Trade routes connected to the settlement
    /// LocalGoods: Goods traded in the settlement
    /// </fields>
    public interface ISettlement
    {
        #region Fields
        
        /// <summary>
        /// The name of the settlement.
        /// </summary>
        string Name { get; set;  }

        /// <summary>
        /// The description of the settlement.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Population of the settlement
        /// </summary>
        int Population { get; set; }

        /// <summary>
        /// Trade routes connected to the settlement
        /// </summary>
        List<TradeRoutes.ITradeRoutes> LocalTradeRoutes { get; set; }

        /// <summary>
        /// Goods traded in the settlement
        /// </summary>
        List<Goods.IGood> LocalGoods { get; set; }

        #endregion
    }
}
