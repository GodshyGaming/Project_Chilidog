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
    /// Type: The type of good
    /// BaseValue: Basic value of the good, before calculating scarcity
    /// </fields>
    public interface IGood : IGameObject
    {
        #region Fields

        /// <summary>
        /// ID of settlement
        /// </summary>
        int ID { get; }

        /// <summary>
        /// The name of the settlement.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The description of the settlement.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Basic unit of the good (kg, lbs, bushel, whatever)
        /// </summary>
        string BasicUnit { get; set; }

        /// <summary>
        /// The type of good
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Basic value of the good, before calculating scarcity
        /// </summary>
        decimal BaseValue { get; set; }

        #endregion
    }
}
