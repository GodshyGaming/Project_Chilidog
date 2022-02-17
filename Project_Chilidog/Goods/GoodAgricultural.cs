namespace Project_Chilidog.Goods
{
    public class GoodAgricultural : IGood
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
        /// The type of good
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Basic value of the good, before calculating scarcity
        /// </summary>
        public decimal BaseValue { get; set; }

        /// <summary>
        /// Time until good expires in days
        /// </summary>
        public int ExpirationTime { get; set; }

        #endregion

        #region Constructors

        public GoodAgricultural(
            string name = "default_name",
            string description = "default_description",
            decimal baseValue = 0,
            int expirationTime = 0
            )
        {
            Name = name;
            Description = description;
            Type = "Agricultural";
            BaseValue = baseValue;
            ExpirationTime = expirationTime;

            int tempID = 0;
            foreach (var item in ConsoleEngine.Program.GlobalGoods)
            {
                if (item.ID > tempID)
                    tempID = item.ID + 1;
            }
            this.ID = tempID;

            ConsoleEngine.Program.GlobalGoods.Add(this);
        }

        #endregion
    }
}
