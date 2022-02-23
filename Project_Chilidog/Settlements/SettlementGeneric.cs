﻿using System;
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
    /// LocalGoods: Goods traded in the settlement
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
        /// The type of trade route
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
        public List<Goods.IGood> LocalGoods { get; set; }

        #endregion

        #region Constructors

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
            LocalGoods = new List<Goods.IGood>();

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
