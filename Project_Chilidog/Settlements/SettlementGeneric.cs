using System;
using System.Collections.Generic;

namespace Project_Chilidog.Settlements
{
    /// <summary>
    /// Generic Settlement object
    /// </summary>
    /// 
    /// <fields>
    /// ID: int identifying the settlement instance
    /// Name: Name of the settlement
    /// Description: Description of the settlement
    /// Type: the type of settlement
    /// Population: population of the settlement
    /// LocalTradeRoutes: list of all locally accesible trade route objects
    /// LocalGoods: list of all locally stocked good objects
    /// </fields>
    public class SettlementGeneric : ISettlement
    {
        #region Fields

        /// <summary>
        /// ID of settlement
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// The name of the settlement.
        /// </summary>
        public string Name { get; set;  }

        /// <summary>
        /// The description of the settlement.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The type of settlement.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Population of the settlement
        /// </summary>
        public int Population { get; set; }

        /// <summary>
        /// Trade routes connected to the settlement
        /// </summary>
        public List<TradeRoutes.ITradeRoute> LocalTradeRoutes { get; set; }

        /// <summary>
        /// Goods traded in the settlement
        /// </summary>
        Dictionary<Goods.IGood, int> LocalGoods { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for a generic Settlement object
        /// </summary>
        /// 
        /// <param name="name">
        /// String name of the settlement to be created
        /// </param>
        /// <param name="description">
        /// string description of the settlement to be created
        /// </param>
        /// <param name="population">
        /// int population to be created
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// name and description are generally pulled from a WriteLine, this is to catch the possible null pass
        /// </exception>
        public SettlementGeneric(
            string name = "default_name",
            string description = "default_description",
            int population = 0
            )
        {
            if (name == null || description == null)
                throw new ArgumentNullException("GoodGeneric Constuctor encountered a null");

            Name = name;
            Description = description;
            Type = "Generic";
            Population = population;
            LocalTradeRoutes = new List<TradeRoutes.ITradeRoute>();
            LocalGoods = new Dictionary<Goods.IGood, int>();

            int tempID = 0;
            foreach (var item in ConsoleEngine.Program.GlobalGoods)
            {
                if (item.ID >= tempID)
                    tempID = item.ID + 1;
            }
            this.ID = tempID;

            ConsoleEngine.Program.GlobalSettlements.Add(this);
        }

        #endregion
    }
}
