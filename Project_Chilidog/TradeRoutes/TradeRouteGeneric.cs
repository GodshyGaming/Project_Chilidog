using System;

namespace Project_Chilidog.TradeRoutes
{

    /// <summary>
    /// generic Trade Route object
    /// </summary>
    /// 
    /// <fields>
    /// ID: ID of trade route
    /// Name: name of trade route
    /// Description: Description of trade route
    /// Type: the type of trade route
    /// DestinationA: One end of the trade route, opposite of DestinationB.
    /// DestinationB: Other end of the trade route, opposite of DestinationA.
    /// Length: Real distance from DestinationA to DestinationB relative to mode of travel
    /// </fields>
    public class TradeRouteGeneric : ITradeRoute
    {
        #region Fields

        /// <summary>
        /// ID of trade route
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// Name of the trade route
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the trade route
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The type of trade route
        /// </summary>
        string Type { get; }

        /// <summary>
        /// One end of the trade route, opposite of DestinationB.
        /// </summary>
        public Settlements.ISettlement DestinationA { get; set; }

        /// <summary>
        /// Other end of the trade route, opposite of DestinationA.
        /// </summary>
        public Settlements.ISettlement DestinationB { get; set; }

        /// <summary>
        /// Real distance from DestinationA to DestinationB relative to mode of travel
        /// </summary>
        public decimal Length { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// basic constructor for generic trade route object
        /// </summary>
        /// 
        /// <param name="DesA">
        /// ISettlement type object of one end of the route
        /// </param>
        /// <param name="DesB">
        /// ISettlement type object of the other end of the route
        /// </param>
        /// <param name="name">
        /// name of the route
        /// </param>
        /// <param name="description">
        /// description of the route
        /// </param>
        /// <param name="length">
        /// decimal length of the route in whatever agreed upon standardized length
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException">
        /// name, description, and length are often taken from WriteLine, this is to catch the rare null pass
        /// </exception>
        public TradeRouteGeneric(
            Settlements.ISettlement DesA,
            Settlements.ISettlement DesB,
            string name = "default_name",
            string description = "default_description",
            decimal length = 0
            )
        {
            if (name == null || description == null)
                throw new ArgumentNullException("GoodGeneric Constuctor encountered a null");

            Name = name;
            Description = description;
            Type = "Generic";
            DestinationA = DesA;
            DestinationB = DesB;
            Length = length;

            int tempID = 0;
            foreach (var item in ConsoleEngine.Program.GlobalGoods)
            {
                if (item.ID >= tempID)
                    tempID = item.ID + 1;
            }
            this.ID = tempID;

            ConsoleEngine.Program.GlobalTradeRoutes.Add(this);
        }

        #endregion
    }
}
