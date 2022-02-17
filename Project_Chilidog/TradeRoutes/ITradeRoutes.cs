﻿namespace Project_Chilidog.TradeRoutes
{
    /// <title>
    /// ITradeRoutes interface
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
    public interface ITradeRoutes
    {
        #region Fields

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
