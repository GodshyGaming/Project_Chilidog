using System.Collections.Generic;

namespace Project_Chilidog.Settlements
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
    /// ID: ID of settlement
    /// Name: The name of the settlement.
    /// Description: The description of the settlement.
    /// Population: Population of the settlement
    /// LocalTradeRoutes: Trade routes connected to the settlement
    /// LocalGoods: Goods traded in the settlement and how much of each is present
    /// </fields>
    public interface ISettlement
    {
        #region Fields

        /// <summary>
        /// ID of settlement
        /// </summary>
        int ID { get; }

        /// <summary>
        /// The name of the settlement.
        /// </summary>
        string Name { get; set;  }

        /// <summary>
        /// The description of the settlement.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// The type of trade route
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Population of the settlement
        /// </summary>
        int Population { get; set; }

        /// <summary>
        /// Trade routes connected to the settlement
        /// </summary>
        List<TradeRoutes.ITradeRoute> LocalTradeRoutes { get; set; }

        /// <summary>
        /// Goods traded in the settlement
        /// </summary>
        Dictionary<Goods.IGood, int> LocalGoods { get; set; }

        #endregion
    }
}
