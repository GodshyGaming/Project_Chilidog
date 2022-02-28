using System;

namespace Project_Chilidog.Goods
{
    /// <summary>
    /// generic Good object
    /// </summary>
    /// 
    /// <fields>
    /// ID: ID of good
    /// Name: Name of the good
    /// Description: Description of the good
    /// Type: The type of good
    /// BaseValue: Basic value of the good, before calculating scarcity
    /// </fields>
    public class GoodGeneric : IGood
    {
        #region Properties

        /// <summary>
        /// ID of good
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// Name of the good
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the good
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Basic unit of the good (kg, lbs, bushel, whatever)
        /// </summary>
        public string BasicUnit { get; set; }

        /// <summary>
        /// The type of good
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Basic value of the good, before calculating scarcity
        /// </summary>
        public decimal BaseValue { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// generic good objects
        /// </summary>
        /// 
        /// <param name="name">
        /// name of the good
        /// </param>
        /// <param name="description">
        /// description of the good
        /// </param>
        /// <param name="basicUnit">
        /// basic unit of trade of the good
        /// </param>
        /// <param name="baseValue">
        /// basic value of the good
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException">
        /// things are often passed from WriteLine, this is to catch a rare null pass
        /// </exception>
        public GoodGeneric(
            string name = "default_name",
            string description = "default_description",
            string basicUnit = "default_unity",
            decimal baseValue = 0
            )
        {
            if ( name == null || description == null )
                throw new ArgumentNullException("GoodGeneric Constuctor encountered a null");

            Name = name;
            Description = description;
            BasicUnit = basicUnit;
            Type = "Generic";
            BaseValue = baseValue;

            int tempID = 0;
            foreach (var item in ConsoleEngine.Program.GlobalGoods)
            {
                if (item.ID >= tempID)
                    tempID = item.ID + 1;
            }
            this.ID = tempID;

            ConsoleEngine.Program.GlobalGoods.Add(this);
        }

        #endregion
    }
}
