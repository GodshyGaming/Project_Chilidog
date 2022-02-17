namespace Project_Chilidog.Goods
{
    /// <title>
    /// IGood interface
    /// </title>
    /// 
    /// <summary>
    /// determines basic behavior for goods objects
    /// </summary>
    /// 
    /// <fields>
    /// ID: ID of good
    /// Name: Name of the good
    /// Description: Description of the good
    /// BaseValue: Basic value of the good, before calculating scarcity
    /// Quantity: Quantity of good being represented
    /// </fields>
    public interface IGood
    {
        #region Fields

        /// <summary>
        /// ID of good
        /// </summary>
        int ID { get; }

        /// <summary>
        /// Name of the good
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Description of the good
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Basic value of the good, before calculating scarcity
        /// </summary>
        decimal BaseValue { get; set; }

        /// <summary>
        /// Quantity of good being represented
        /// </summary>
        int Quantity { get; set; }

        #endregion
    }
}
