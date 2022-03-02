using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Chilidog
{
    public interface IGameObject
    {
        #region Properties

        /// <summary>
        /// ID of merchant
        /// </summary>
        int ID { get; }

        /// <summary>
        /// Name of the Merchant
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Description of the Merchant
        /// </summary>
        string Description { get; set; }

        #endregion
    }
}
