namespace Project_Chilidog.Merchants
{
    /// <title>
    /// IMerchant interface
    /// </title>
    /// 
    /// <summary>
    /// determines basic behavior for merchant objects
    /// </summary>
    public interface IMerchant
    {
        #region Fields

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
