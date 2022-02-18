using System.Collections.Generic;

namespace Project_Chilidog.Merchants
{
    /// <title>
    /// IMerchant interface
    /// </title>
    /// 
    /// <summary>
    /// determines basic behavior for merchant objects
    /// </summary>
    /// 
    /// <fields>
    /// ID: ID of Merchant
    /// Name: Name of the Merchant
    /// Description: Description of the Merchant
    /// CashOnHand: Cash currently in Merchant's inventory
    /// InventoriedGoods: Goods currently in the Merchant's inventory
    /// </fields>
    public interface IMerchant
    {
        #region Fields

        /// <summary>
        /// ID of merchant
        /// </summary>
        int ID { get; }

        /// <summary>
        /// Name of the Merchant
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Description of the Merchant
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Cash currently in Merchant's inventory
        /// </summary>
        decimal CashOnHand { get; set; }

        /// <summary>
        /// Goods currently in the Merchant's inventory
        /// </summary>
        List<Goods.IGood> InventoriedGoods { get; set; }

        #endregion
    }
}
