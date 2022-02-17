namespace Project_Chilidog.TradeRoutes
{
    /// <title>
    /// ITradeRoute interface
    /// </title>
    /// 
    /// <summary>
    /// determines basic behavior for trade route objects
    /// </summary>
    /// 
    /// <fields>
    /// DestinationA: One end of the trade route, opposite of DestinationB.
    /// DestinationB: Other end of the trade route, opposite of DestinationA.
    /// Length: Real distance from DestinationA to DestinationB relative to mode of travel
    /// </fields>
    public interface ITradeRoute
    {
        #region Fields

        /// <summary>
        /// Name of the trade route
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Description of the trade route
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// One end of the trade route, opposite of DestinationB.
        /// </summary>
        Settlements.ISettlement DestinationA { get; set; }

        /// <summary>
        /// Other end of the trade route, opposite of DestinationA.
        /// </summary>
        Settlements.ISettlement DestinationB { get; set; }

        /// <summary>
        /// Real distance from DestinationA to DestinationB relative to mode of travel
        /// </summary>
        decimal Length { get; set; }

        #endregion
    }
}
